using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Bullets
{
    public class BulletPool
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;
        List<PooledBullet> pooledBullets = new List<PooledBullet>();
        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject)
        {
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }
        public BulletController GetBullet()
        {
            if (pooledBullets.Count > 0)
            {
                PooledBullet pooledBullet = pooledBullets.Find(bullet => !bullet.isUsed);
                if (pooledBullet != null)
                {
                    pooledBullet.isUsed = true;
                    return pooledBullet.bulletController;
                }
            }
            return CreateBullet();
        }

        public void ReturnToBulletPool(BulletController returnedBullet)
        {
            PooledBullet pooledBullet = pooledBullets.Find(bullet => bullet.bulletController.Equals(returnedBullet));
            pooledBullet.isUsed = false;
        }

        private BulletController CreateBullet()
        {
            PooledBullet bullet = new PooledBullet();
            bullet.isUsed = true;
            bullet.bulletController = new BulletController(bulletView, bulletScriptableObject);
            pooledBullets.Add(bullet);
            return bullet.bulletController;
        }
    }

    public class PooledBullet
    {
        public BulletController bulletController;
        public bool isUsed;
    }
}