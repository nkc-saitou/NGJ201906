using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(menuName = "CustomMenu/SquareDataSerializeCreate", fileName = "SquareDataSerialize")]
public class SquareDataSerialize : ScriptableObject,ISerializationCallbackReceiver {

    /// <summary>
    /// マップデータ
    /// </summary>
    public List<List<int>> Map { get; set; }

    [SerializeField, HideInInspector]
    List<ListInt> serializableMap;

    /// <summary>
    /// Unityだと２次元入れるがシリアライズ化できないので、シリアライズ化できる形式に分解
    /// </summary>
    public void OnBeforeSerialize()
    {
        // mapのすべての要素をListIntに変換して保存しておく
        serializableMap = Map == null ? null : Map.Select(subList => new ListInt(subList)).ToList();
    }

    /// <summary>
    /// データを２次元に戻す
    /// </summary>
    public void OnAfterDeserialize()
    {
        // serializableMapに保存した要素をmapに全て戻す
        Map = serializableMap == null ? null : serializableMap.Select(listInt => listInt.data).ToList();
    }
}

[Serializable]
public class ListInt
{
    public List<int> data;

    public ListInt(List<int> list)
    {
        // null合体演算子
        data = list ?? new List<int>();
    }
}
