﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace shima
{
    public class plusmasuController : MonoBehaviour, ISquaresCall
    {
        GameObject infomation;
        GameObject textbox;
        // Use this for initialization
        void Start()
        {
            this.infomation = GameObject.Find("infomation");
            this.textbox = GameObject.Find("textbox");
        }

        // Update is called once per frame
        void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Return))//エンターキーでインターフェース呼び出し
            //{
            //    GameObject director = GameObject.Find("plusprefab");
            //    director.GetComponent<plusmasuController>().SquaresCall();

            //}
            //if (Input.GetKeyDown(KeyCode.Space))//スペースキーでテキスト消去
            //{
            //    //this.infomation.GetComponent<Text>().color = new Color(1, 1, 1, 0);
            //}
            //this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 0);テキスト欄消去
        }

        public void SquaresCall()
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().koukandoUp();
        }
    }
}
