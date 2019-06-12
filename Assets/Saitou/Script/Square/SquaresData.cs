using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Saitou.Squares;

[CreateAssetMenu(menuName = "CustomMenu/SquaresDataCreate", fileName = "SquaresData")]
public class SquaresData : ScriptableObject {

    /// <summary>
    /// マス目のデータ
    /// </summary>
    public List<SquareType> SquaresDataLis = new List<SquareType>();

    /// <summary>
    /// マス目を管理している親オブジェクト
    /// </summary>
    public GameObject SquaresObjectPre;
}
