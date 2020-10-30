using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SoldierCamp:ICamp
{
    SoldierGenerater soldierGenerater;
    public SoldierCamp(GameObject campGO, string name, string icon, CampType campType) : base(campGO, name, icon, campType)
    {
        soldierGenerater = mCampGO.GetComponent<SoldierGenerater>();
        soldierGenerater.CampType = mCampType;
        soldierGenerater.enabled = true;
    }

}

