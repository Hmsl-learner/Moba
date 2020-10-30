﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class UnityTool
{
    public static GameObject FindChild(GameObject parent, string name)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        bool isFind = false;
        Transform child = null;
        foreach(Transform t in children)
        {
            if(t.name == name)
            {
                if (isFind){
                    Debug.LogWarning("在游戏物体" + parent + "存在不止一个子物体:" + child.name);return null;
                }
                isFind = true;
                child = t;
                
            }
        }
        if(isFind) return child.gameObject;
        return null;
    }

    public static void Attach(GameObject parent, GameObject child)
    {
        child.transform.parent = parent.transform;
        child.transform.localPosition = Vector3.zero;
        child.transform.localEulerAngles = Vector3.zero;
        child.transform.localScale = Vector3.one;
    }
}

