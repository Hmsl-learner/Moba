using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// 挂在特效上面 实现定时销毁功能
public class DestroyForTime:MonoBehaviour
{
    public float time = 1f;
    private void Start()
    {
        Invoke("Destroy", time);
    }
    void Destroy()
    {
        GameObject.DestroyImmediate(this.gameObject);
    }
}

