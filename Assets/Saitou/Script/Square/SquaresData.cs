using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Saitou.Squares;

[CreateAssetMenu(menuName = "CustomMenu/SquaresDataCreate", fileName = "SquaresData")]
public class SquaresData : ScriptableObject {

    /// <summary>
    /// マス目のデータ
    /// </summary>
    public List<List<int>> SquaresDataLis = new List<List<int>>();
}
