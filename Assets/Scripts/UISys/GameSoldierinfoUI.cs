using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameSoldierinfoUI : IBaseUI
{
    private Image mSoldierIcon;
    private Text mSoldierName;
    private Text mHP;
    private Slider mHPSlider;
    private Text mLv;
    private Text mAtk;
    private Text mAtkRange;
    private Text mMoveSpeed;

    private ICharacter mSolider;

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "SoldierInfoUI");

        mSoldierIcon = UITool.FindChild<Image>(mRootUI, "SoldierIcon");
        mSoldierName = UITool.FindChild<Text>(mRootUI, "SoldierName");
        mHP = UITool.FindChild<Text>(mRootUI, "HP");
        mHPSlider = UITool.FindChild<Slider>(mRootUI, "HPSlider");
        mLv = UITool.FindChild<Text>(mRootUI, "Level");
        mAtk = UITool.FindChild<Text>(mRootUI, "Atk");
        mAtkRange = UITool.FindChild<Text>(mRootUI, "AtkRange");
        mMoveSpeed = UITool.FindChild<Text>(mRootUI, "MoveSpeed");

        Hide();
    }

    public override void Update()
    {
        base.Update();
        if (mSolider != null) UpdateSoldierInfo(mSolider);

    }
    public void ShowSoldierInfo(ICharacter soldier)
    {
        mFacade.HideCamp();
        Show();
        mSolider = soldier;
        mSoldierIcon.sprite = FactoryManager.assetFactory.LoadSprite(soldier.attr.IconSprite);
        mSoldierName.text = soldier.attr.Name;
        mLv.text = soldier.attr.Lv.ToString();
        mAtk.text = soldier.atk.ToString();
        mAtkRange.text = soldier.atkRange.ToString();
        mMoveSpeed.text = soldier.attr.MoveSpeed.ToString();

    }
    public void UpdateSoldierInfo(ICharacter soldier)
    {
        mHP.text = "(" + soldier.attr.CurrentHP + "/" + soldier.attr.MaxHP + ")";
        mHPSlider.value = soldier.attr.CurrentHP / soldier.attr.MaxHP;
        //Debug.Log(mHPSlider.value);
    }
    public void HideSoldier()
    {
        Hide();
    }
}
   

