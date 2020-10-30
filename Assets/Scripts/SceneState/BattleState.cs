using System;
using System.Collections.Generic;
using System.Text;

public class BattleState : ISceneState
{
    public BattleState(SceneStateController controller) : base("03-Battle",controller)
    { }

    // 兵营 角色管理 行动力 。。。
    public override void StateStart()
    {
        GameManager.Instance.Init();
    }
    public override void StateEnd()
    {
        GameManager.Instance.Release();
    }
    public override void StateUpdate()
    {
        if (GameManager.Instance.IsGameOver)
        {
            mController.SetState(new MainMenuState(mController));
        }
        GameManager.Instance.Update();
    }
    

}

