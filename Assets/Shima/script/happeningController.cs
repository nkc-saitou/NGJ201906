using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace shima
{
    public class happeningController : MonoBehaviour,ISquaresCall
    {
        float random;
        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void SquaresCall()
        {
            this.random = Random.Range(0f, 4f);
            if (this.random >= 0f && this.random < 1f)
            {
                this.random = 0;
                GameObject director = GameObject.Find("GameDirector");
                director.GetComponent<GameDirector>().koukandoUp();
            }
            else if (this.random >= 1f && this.random < 2f)
            {
                this.random = 0;
                GameObject director1 = GameObject.Find("GameDirector");
                director1.GetComponent<GameDirector>().koukandoDown();
            }
        }
    }
}
