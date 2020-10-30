using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private SceneStateController controller;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = new SceneStateController();
        controller.SetState(new StartState(controller), false);
    }

    // Update is called once per frame
    void Update()
    {
        if (controller != null)
        {
            controller.StateUpdate();
        }
    }

}