using System.Collections.Generic;

namespace CosmicCuration.Enemy
{ 
    public class EnemyPool
    {
        private EnemyData EnemyData;
        private EnemyView EnemyView;
        private List<PooledEnemies> pooledEnemies = new List<PooledEnemies>();
        public EnemyPool(EnemyData enemyData, EnemyView enemyView)
        {
            EnemyData = enemyData;
            EnemyView = enemyView;
        }

        public EnemyController GetEnemy()
        {
            if (pooledEnemies.Count > 0)
            {
                PooledEnemies existingEnemy = pooledEnemies.Find(enemy => !enemy.isUsed);
                if (existingEnemy != null)
                {
                    existingEnemy.isUsed = true;
                    return existingEnemy.enemyController;
                }
            }
            return CreateEnemy();
        }

        public void ReturnEnemyToPool(EnemyController enemyController)
        {
            PooledEnemies existingEnemy = pooledEnemies.Find(enemy => enemy.enemyController.Equals(enemyController));
            existingEnemy.isUsed = false;
        }

        private EnemyController CreateEnemy()
        {
            PooledEnemies newEnemy = new PooledEnemies();
            newEnemy.enemyController = new EnemyController(EnemyView, EnemyData);
            newEnemy.isUsed = true;
            pooledEnemies.Add(newEnemy);
            return newEnemy.enemyController;
        }
    }
    public class PooledEnemies
    {
        public EnemyController enemyController;
        public bool isUsed;
    }
}