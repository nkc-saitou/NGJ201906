using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Saitou.Squares
{

    public class SquareLineRenderer : MonoBehaviour
    {
        public LineRenderer line;

        public void DrawLine(Transform target1,Transform target2)
        {
            line.SetPosition(0, target1.position);
            line.SetPosition(1, target2.position);
        }
    }
}
