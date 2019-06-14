using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestData : MonoBehaviour {

    public SquareDataSerialize data;

    [ContextMenu("LogMenu")]
    void MapData()
    { 
        int indexX = data.Map.Count;
        Debug.Log(indexX);

        for (int i = 0; i < indexX; i++)
        {
            for (int j = 0; j < indexX; j++)
            {
                Debug.Log(data.Map[j][i]);
            }
        }
    }
}
