using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Saitou.Test;
using Saitou.System;

namespace Saitou.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [Header("テスト用")]
        ISquareList<Transform> squareLis;
        List<Transform> squareTransformLis = new List<Transform>();

        // Use this for initialization
        void Start()
        {
            squareLis = FindInterface.FindObjectOfInterfaces<ISquareList<Transform>>();
            Debug.Log(squareLis.SquareLis);
            //squareTransformLis.AddRange(squareLis.SquareLis);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
