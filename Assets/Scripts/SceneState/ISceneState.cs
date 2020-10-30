using System;
using System.Collections.Generic;
using System.Text;


public class ISceneState
{
    private string mSceneName;
    protected SceneStateController mController;

    public ISceneState(string sceneName, SceneStateController controller)
    {
        mSceneName = sceneName;
        mController = controller;
    }


    public string SceneName
    {
        get { return mSceneName; }
    }

    public virtual void StateStart() { }    // 进入到状态时调用
    public virtual void StateEnd() { }      // 离开状态时调用
    public virtual void StateUpdate() { }
    
}
   

