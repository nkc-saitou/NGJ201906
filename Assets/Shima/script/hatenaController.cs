using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace shima
{

    public class hatenaController : MonoBehaviour, ISquaresCall
    {
        GameObject text;
        int random = 0;
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
            this.random = Random.Range(0, 3);
            if (this.random >= 0 && this.random < 1)
            {
                this.text.GetComponent<Text>().text =//テキスト表示
                              "テディベアを手に入れた！！";
            }
            if (this.random >= 1 && this.random < 2)
            {
                this.text.GetComponent<Text>().text =//テキスト表示
                             "王道少女漫画を手に入れた！！";
            }
            if (this.random >= 2)
            {
                this.text.GetComponent<Text>().text =//テキスト表示
                            "乙女ゲームを手に入れた！！";    
            }
        }
    }
}
