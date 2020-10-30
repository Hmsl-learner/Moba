using System;
using System.Collections.Generic;
using System.Text;


public interface IAttrStrategy
{
    // 获得登记提供的额外血量值
    int GetExtraHPValue(int lv);
    // 获得伤害减免值
    int GetDmgDescValue(int lv);
    // 获得暴击伤害值
    int GetCritDmgValue(float critRate);
}

