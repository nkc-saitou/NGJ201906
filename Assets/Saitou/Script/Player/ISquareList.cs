using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Saitou.Test
{
    public interface ISquareList<T>
    {

        List<T> SquareLis { get; set; }
    }
}