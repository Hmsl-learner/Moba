using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class UITool
{
    // 获取画布
    public static GameObject GetCanvas(string name="Canvas")
    {
        return  GameObject.Find(name);
    }

    /// <summary>
    /// 查找parent下面名为name的物体身上的T组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="parent"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static T FindChild<T>(GameObject parent, string name)
    {
        GameObject uiGO = UnityTool.FindChild(parent, name);
        if (uiGO == null)
        {
            Debug.LogError("在游戏物体" + parent + "查找不到" + name);
            return default(T);
        }
        
        return uiGO.GetComponent<T>();
    }
}

