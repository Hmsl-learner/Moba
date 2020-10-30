using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public interface ICharacterFactory
{
    // 创建角色
    ICharacter CreatCharacter<T>(Vector3 spawnPosition,Transform startParent, RoadType roadType, CampType campType, Transform[] towers, int lv = 1) where T : ICharacter, new();
}

