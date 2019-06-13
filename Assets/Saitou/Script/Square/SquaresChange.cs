using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Saitou.Squares
{
    public class SquaresChange : MonoBehaviour
    {

        //[SerializeField]
        //Sprite[] sprites;

        //[SerializeField]
        //SquaresData data;

        //List<SquareType> squareLis = new List<SquareType>();


        // Use this for initialization
        void Start()
        {
            //squareLis.AddRange(data.SquaresDataLis);

            //foreach(SquareType type in squareLis)
            //{
            //    type.changeHandler += (squareType, renderer) 
            //        => renderer.sprite = sprites[(int)squareType];
            //}
        }

        /// <summary>
        /// インスペクターから値を変更した時に呼び出される
        /// </summary>
        void OnValidate()
        {
            //foreach (SquareType type in squareLis)
            //{
            //    type.changeHandler += (squareType, renderer)
            //        => renderer.sprite = sprites[(int)squareType];
            //}
        }
    }
}
