using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierBuilder : ICharacterBuilder
{
    public SoldierBuilder(Transform startParent, ICharacter character, System.Type t, Vector3 spawnPosition, RoadType roadType,
        CampType campType, Transform[] towers) : base(startParent, character, t, spawnPosition,roadType,campType,towers)
    {
    }

  

    public override void AddCharacterGO()
    {
        // 创建角色游戏物体
        // 1.加载 2.实例化 3.加载Mono组件
        GameObject characterGO = FactoryManager.assetFactory.LoadSoldier(mPrefabName,mStartParent);
        //characterGO.transform.position = mSpawnPosition;
        mCharacter.gameObject = characterGO;
        mCharacter.mono = mCharacter.gameObject.GetComponentInChildren<SoldierMono>();
        mCharacter.mono.SetSoldier(mCharacter as ISoldier);
        mCharacter.mono.SetCamp(mCampType);
    }
    public override void AddAttr()
    {
        mCharacter.attr = new ICharacterAttr(new SoldierAttrStrategy(), "小兵", "soldier", 100, 100, 66, 100, 45, 35, 0.6f, 320);
    }

    public override void AddInCharacterSys()
    {
        GameManager.Instance.AddSoldier(mCharacter as ISoldier);
    }


    public override ICharacter GetResult()
    {
        return mCharacter;
    }
    /// <summary>
    /// 设置路线
    /// </summary>
    public override void SetRoad()
    {
        mCharacter.roadType = mRoadType;
    }
    /// <summary>
    /// 设置目标
    /// </summary>
    public override void SetTargets()
    {
        mCharacter.targets = mTowers;
    }
    /// <summary>
    /// 设置阵营
    /// </summary>
    public override void SetType()
    {
        mCharacter.campType = mCampType;
    }
}

