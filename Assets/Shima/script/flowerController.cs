using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace shima
{

    public class flowerController : MonoBehaviour, ISquaresCall
    {
        GameObject text;

        // Use this for initialization
        void Start()
        {
            this.text = GameObject.Find("infomation");
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void SquaresCall()
        {
            this.text.GetComponent<Text>().text =//テキスト表示
                "花束を手に入れた！！";
        }
    }
}
