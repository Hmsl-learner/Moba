using System;
using System.Collections.Generic;
using System.Text;


public class EnemyAttrStrategy : IAttrStrategy
{
    public int GetCritDmgValue(float critRate)
    {
        if(UnityEngine.Random.Range(0, 1f)<critRate)
        {
            return 2;
        }
        return 1;
    }

    public int GetDmgDescValue(int lv)
    {
        return 0;
    }

    public int GetExtraHPValue(int lv)
    {
        return 0;
    }
}

