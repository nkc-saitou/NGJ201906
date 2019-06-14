using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace shima
{

    public class flowerController : MonoBehaviour, ISquaresCall
    {
        GameObject text;
        GameObject textbox;

        // Use this for initialization
        void Start()
        {
            this.text = GameObject.Find("infomation");
            this.textbox = GameObject.Find("textbox");
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))//エンターキーでインターフェース呼び出し
            {
                GameObject happening = GameObject.Find("specialmasu(flower)");
                happening.GetComponent<flowerController>().SquaresCall();
            }
                if (Input.GetKeyDown(KeyCode.Space))//スペースキーでテキスト消去
            {
                //this.infomation.GetComponent<Text>().color = new Color(1, 1, 1, 0);

            }
            //this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 0);テキスト欄消去
        }
        public void SquaresCall()
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().flower();
            this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 1);//テキスト欄表示
            this.text.GetComponent<Text>().text =//テキスト表示
                "花束を手に入れた！！";
        }
    }
}
