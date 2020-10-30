using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierFactory : ICharacterFactory
{
    public ICharacter CreatCharacter<T>(Vector3 spawnPosition, Transform startParent, RoadType roadType, CampType campType, Transform[] towers, int lv = 1) where T : ICharacter, new()
    {
        ICharacter soldier = new T(); // 创建角色 添加状态机

        CharacterBuilderDirector director = new CharacterBuilderDirector(); // 创建指导者
        SoldierBuilder builder = new SoldierBuilder(startParent, soldier, typeof(T), spawnPosition,roadType,campType,towers);   // 创建Soldier建造者

        return director.Construct(builder); // 建造Soldier并返回

        
    }
}

