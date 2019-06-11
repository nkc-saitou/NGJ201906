﻿using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class OvalMove
{

    private static bool m_isCompiling = false;

    static OvalMove()
    {
        //エディタで再生中に毎秒約100回呼ばれるコールバック
        EditorApplication.update += () =>
        {
            if (Input.GetMouseButtonDown(0)) Debug.Log("ok");
        };
    }



}
