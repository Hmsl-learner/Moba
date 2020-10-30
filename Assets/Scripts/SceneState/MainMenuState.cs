using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : ISceneState
{
    public MainMenuState(SceneStateController controller) : base("02-Login", controller)
    { }

    public override void StateStart()
    {
        GameObject.Find("StartBtn").GetComponent<Button>().onClick.AddListener(OnStartButtononClick);
        GameObject.Find("ExitBtn").GetComponent<Button>().onClick.AddListener(OnExitButtononClick);
    }
    private void OnStartButtononClick()
    {
        mController.SetState(new BattleState(mController));
    }
    private void OnExitButtononClick()
    {
        Application.Quit();
    }
}
    

