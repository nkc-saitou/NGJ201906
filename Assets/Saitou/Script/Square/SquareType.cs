﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Saitou.Squares
{
    /// <summary>
    /// マスの種類を列挙
    /// </summary>
    public enum E_SqureType
    {
        none,
        start,
        goal,
        up,
        down,
        pulpunte,
        specialOne,
        specialTwo,
        specialThree,
        maxImageType,
    }

    /// <summary>
    /// マスのタイプを指定
    /// </summary>
    public class SquareType : MonoBehaviour
    {
        [Header("マスの種類")]
        public E_SqureType TempSquare;

        /// <summary>
        /// マスの種類
        /// </summary>
        public E_SqureType Square {
            get { return TempSquare; }
            set { TempSquare = value; }
        }

        List<Position> positionLis = new List<Position>();
        public List<Position> PositionLis {
            get { return positionLis; }
            set { positionLis = value; }
        }

    }
}
