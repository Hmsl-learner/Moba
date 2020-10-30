using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class ICamp
{
    protected GameObject mCampGO;   // 物体
    protected string mName; // 名字
    protected string mIconSprite;   // 图标
    protected int mHPValue;   // 水晶生命值
    protected CampType mCampType;   // 阵营

    public string name { get { return mName; } }
    public string iconSprite { get { return mIconSprite; } }
    public ICamp(GameObject campGO,string name,string icon,CampType campType)
    {
        mCampGO = campGO;
        mName = name;
        mIconSprite = icon;
        mCampType = campType;
        mHPValue = 100;
    }

    public virtual void Update() {

    }

    public virtual void UnderAttack(int damage)
    {
        mHPValue -= damage;
        if (mHPValue <= 0) GameOver();
    }
    public virtual void GameOver()
    {

    }
    public void PlayGameOverEffect()
    {

    }
}

