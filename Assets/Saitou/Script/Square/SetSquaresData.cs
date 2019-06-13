using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Saitou.Squares
{
    public class SetSquaresData : MonoBehaviour
    {
        [Header("マス目保存したいデータ"),SerializeField]
        SquaresData data;

        //List<SquareType> typeLis = new List<SquareType>();

        [ContextMenu("SetData")]
        void Create()
        {
            //data.SquaresObjectPre = gameObject;

            //foreach(Transform obj in transform) typeLis.Add(obj.GetComponent<SquareType>());
            //data.SquaresDataLis.AddRange(typeLis);
        }

        [ContextMenu("ResetData")]
        void Reset()
        {
            //if (data.SquaresDataLis.Count < 0) return;

            //data.SquaresDataLis.Clear();
            //typeLis.Clear();

        }
    }
}
