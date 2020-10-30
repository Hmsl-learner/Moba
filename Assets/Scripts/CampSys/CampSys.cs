using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampSys : IGameSys
{
    private ICamp mRedCamp;
    private ICamp mBlueCamp;
    public override void Init()
    {
        base.Init();
        InitCamp();
    }

    // 初始化兵营
    private void InitCamp()
    {
        string campIcon_red = "";
        GameObject go = UnityTool.FindChild(mMapParentGO, "RedCamp");
        mRedCamp = new SoldierCamp(go, "RedCamp", campIcon_red, CampType.Red);

        string campIcon_blue = "";
        go = UnityTool.FindChild(mMapParentGO, "BlueCamp");
        mBlueCamp = new SoldierCamp(go, "BlueCamp", campIcon_blue, CampType.Blue);
    }

    public override void Update()
    {
        mRedCamp.Update();
        mBlueCamp.Update();
    }
}
