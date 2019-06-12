using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace shima
{
    public class plusmasuController : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().koukandoUp();
        }
    }
}
