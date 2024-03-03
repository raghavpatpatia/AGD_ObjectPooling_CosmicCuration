using System;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T : class
    {
        private List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();
        protected T GetItem()
        {
            if (pooledItems.Count > 0)
            {
                PooledItem<T> existingItem = pooledItems.Find(item => !item.isUsed);
                if (existingItem != null)
                {
                    existingItem.isUsed = true;
                    return existingItem.item;
                }
            }
            return CreatePooledItem();
        }
        private T CreatePooledItem() 
        { 
            PooledItem<T> pooledItem = new PooledItem<T>();
            pooledItem.item = CreateItem();
            pooledItem.isUsed = true;
            pooledItems.Add(pooledItem);
            return pooledItem.item;
        }
        protected virtual T CreateItem() => throw new NotImplementedException("Child class does not have implementation of CreateItem().");
    }
    public class PooledItem<T> where T : class
    {
        public T item;
        public bool isUsed;
    }
}