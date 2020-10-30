using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// 统一管理工厂 提供工厂接口
public static class FactoryManager
{
    private static IAssetFactory mAssetFactory = null;
    private static ICharacterFactory mSoldierFactory = null;
    private static ICharacterFactory mEnemyFactory = null;

   
    public static IAssetFactory assetFactory
    {
        get
        {
            if (mAssetFactory == null)
            {
                mAssetFactory = new ResourcesAssetFactory();
            }
            return mAssetFactory;
        }
    }
    public static ICharacterFactory soldierFactory
    {
        get
        {
            if(mEnemyFactory == null)
            {
                mEnemyFactory = new SoldierFactory();
            }
            return mEnemyFactory;
        }
    }
   
   
}

