using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace shima
{

    public class TestLine : MonoBehaviour
    {

        public Transform startPos;
        public Transform endPos;

        LineRenderer line;

        private void Start()
        {
            line = GetComponent<LineRenderer>();

            line.positionCount = 2;
        }

        private void Update()
        {
            line.SetPosition(0, startPos.position);
            line.SetPosition(1, endPos.position);
        }
    }
}
