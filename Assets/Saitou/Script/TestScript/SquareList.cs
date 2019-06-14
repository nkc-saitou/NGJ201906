using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Saitou.Test
{
    public class SquareList : MonoBehaviour,ISquareList<Transform>
    {

        public List<Transform> SquareLis { get; set; }

        void Awake()
        {
            SquareLis = new List<Transform>();

            foreach (Transform lis in transform)
            {
                SquareLis.Add(lis);
            }
        }

        void Start()
        {

        }
    }
}