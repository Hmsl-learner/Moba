using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : IBaseUI
{
    private Text mCurrentStageLv;
    private Button mContinueBtn;
    private Button mBackMenueBtn;

    public override void Init()
    {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "GamePauseUI");

        mCurrentStageLv = UITool.FindChild<Text>(mRootUI, "CurrentStageLv");
        mContinueBtn = UITool.FindChild<Button>(mRootUI, "ContinueBtn");
        mBackMenueBtn = UITool.FindChild<Button>(mRootUI, "BackMenueBtn");

        mContinueBtn.onClick.AddListener(OnContinueClick);
        mBackMenueBtn.onClick.AddListener(OnBackMenueClick);
        Hide();
    }
    public void ShowPauseUI()
    {
        Show();
    }
    private void OnContinueClick()
    {
        Time.timeScale = 1; 
        Hide();
    }
    private void OnBackMenueClick()
    {
        //TODO
        mFacade.IsGameOver = true;
    }
}
