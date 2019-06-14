using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Saitou.Squares
{
    /// <summary>
    /// マスの種類を列挙
    /// </summary>
    public enum E_SqureType
    {
        none = 0,
        start,
        goal,
        loveUp,
        loveDown,
        special,
    }

    /// <summary>
    /// マスのタイプを指定
    /// </summary>
    public class SquareType : MonoBehaviour
    {
        [Header("マスの種類")]
        public E_SqureType tempSqure;

        /// <summary>
        /// マスの種類
        /// </summary>
        public E_SqureType Squre {
            get { return tempSqure; }
            set { tempSqure = value; }
        }

        List<Position> positionLis = new List<Position>();
        public List<Position> PositionLis {
            get { return positionLis; }
            set { positionLis = value; }
        }

    }
}
