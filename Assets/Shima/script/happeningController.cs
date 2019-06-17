﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace shima
{
    public class happeningController : MonoBehaviour, ISquaresCall
    {
        bool kaiwa = false;
        Text infomation;
        GameObject textbox;
        float random;
        //Text text;
        int tap=0;
        // Use this for initialization
        void Start()
        {
            this.infomation = GameObject.Find("infomation").GetComponent<Text>();
            this.textbox = GameObject.Find("textbox");
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))// エンターキーでインターフェース呼び出し
            {
            GameObject happening = GameObject.Find("happeningprefab");
            happening.GetComponent<happeningController>().SquaresCall();
            }
            if (Input.GetKeyDown(KeyCode.Return))//エンターキーでテキスト消去
            {
                //this.infomation.GetComponent<Text>().color = new Color(1, 1, 1, 0);

            }
            //this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 0);テキスト欄消去
            if (this.kaiwa&&Input.GetKeyDown(KeyCode.Space)) {//スペースキーを押した回数でテキスト進行
                switch (tap)
                {

                    case 0:this.infomation.text = "こんなチャンスもう二度とないかも知れない！";
                        break;
                    case 1:  this.infomation.GetComponent<Text>().text ="今ここで告白だ！！！";
                        break;
                    case 2:SceneManager.LoadScene("Result");
                        break;
                    default:
                        break;
                }
                tap++;
            }
        }
        public void SquaresCall()
        {
            this.random = Random.Range(0f, 100f);
            if (this.random >= 0f && this.random < 45f)
            {
                this.random = 0;
                GameObject director = GameObject.Find("GameDirector");
                director.GetComponent<GameDirector>().koukandoUp();
            }
            else if (this.random >= 45f && this.random <90f)
            {
                this.random = 0;
                GameObject director1 = GameObject.Find("GameDirector");
                director1.GetComponent<GameDirector>().koukandoDown();
            }
            else if (this.random >= 90 && this.random < 99)
            {
                GameObject director2 = GameObject.Find("GameDirector");
                director2.GetComponent<GameDirector>().taxi();
            }
            else if (this.random >= 99)//最初にテキスト表示
            {
                infomation.color = new Color(1, 1, 1, 1);
                this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                this.infomation.text = "なんと！愛しのお嬢様が目の前に現れた！";
                this.kaiwa = true;
            }

        }
    }
}
