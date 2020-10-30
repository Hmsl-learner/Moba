using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerBuilder : ICharacterBuilder
{
    public PlayerBuilder(Transform startParent, ICharacter character, System.Type t, Vector3 spawnPosition, RoadType roadType,
        CampType campType, Transform[] towes) : base(startParent, character, t, spawnPosition,roadType,campType,towes)
    {
    }

    public override void AddAttr()
    {
        throw new NotImplementedException();
    }


    // 建造物体
    public override void AddCharacterGO()
    {
        // 创建角色游戏物体
        // 1.加载 2.实例化 TODO
        GameObject characterGO = FactoryManager.assetFactory.LoadPlayer(mPrefabName,mStartParent);
        characterGO.transform.position = mSpawnPosition;
        mCharacter.gameObject = characterGO;
        characterGO.AddComponent<SoldierOnCilck>().soldier = mCharacter;
    }

    public override void AddInCharacterSys()
    {
        GameManager.Instance.AddPlayer(mCharacter as IPlayer);
    }

   
    // 输出角色
    public override ICharacter GetResult()
    {
        return mCharacter;
    }

    public override void SetRoad()
    {
    }

    public override void SetTargets()
    {

    }

    public override void SetType()
    {

    }
}

