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
        GameObject textbox;

        bool isFirst = true;
        // Use this for initialization
        void Start()
        {
            this.text = GameObject.Find("infomation");
            this.textbox = GameObject.Find("textbox");
        }

        // Update is called once per frame
        void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Return))//エンターキーでインターフェース呼び出し
            //{
            //    GameObject happening = GameObject.Find("specialmasu(hatena)");
            //    happening.GetComponent<hatenaController>().SquaresCall();
            //}
            //if (Input.GetKeyDown(KeyCode.Space))//スペースキーでテキスト消去
            //{
            //    //this.infomation.GetComponent<Text>().color = new Color(1, 1, 1, 0);
               
            //}
            ////this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 0);//テキスト欄消去
        }
        public void SquaresCall()
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().hatena(isFirst);

            if (isFirst)
            {
                this.random = Random.Range(0, 3);
                if (this.random >= 0 && this.random < 1)
                {
                    this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 1);//テキスト欄表示
                    this.text.GetComponent<Text>().text =//テキスト表示
                                  "テディベアを手に入れた！！";
                }
                if (this.random >= 1 && this.random < 2)
                {
                    this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 1);//テキスト欄表示
                    this.text.GetComponent<Text>().text =//テキスト表示
                                 "王道少女漫画を手に入れた！！";
                }
                if (this.random >= 2)
                {
                    this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 1);//テキスト欄表示
                    this.text.GetComponent<Text>().text =//テキスト表示
                                "乙女ゲームを手に入れた！！";
                }

                isFirst = false;
            }
            else
            {
                this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 1);//テキスト欄表示
                this.text.GetComponent<Text>().text =//テキスト表示
                              "すでに手に入れてる！";
            }
        }
    }
}
