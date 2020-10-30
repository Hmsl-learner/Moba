using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CampType
{
    Red, Blue
}
public enum RoadType
{
    Mid = 1 << 3,
    Up = 1 << 4,
    Down = 1 << 5
}
public enum PlayerType
{
    Ahri,
}
public enum SoldierType
{
    Warrior,
    Wizard,
    Cannon
}
// 状态转换条件
public enum SoldierTransition
{
    NullTransition = 0,
    CanAttack,
    LostSoldier
}
// 状态ID
public enum SoldierStateID
{
    NullState = 0,
    Chase,
    Attack

}
