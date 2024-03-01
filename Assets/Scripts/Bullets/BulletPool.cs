using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Bullets
{
    public class BulletPool : MonoBehaviour
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;
        List<PooledBullet> pooledBullet = new List<PooledBullet>();
        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject)
        {
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }
    }
    public class PooledBullet
    {
        public BulletController bulletController;
        public bool isUsed;
    }
}