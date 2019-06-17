using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace shima
{
    public class GameDirector : MonoBehaviour
    {
        GameObject text;
        GameObject infomation;
        GameObject textbox;
       public int lovePoint = 50;//好感度の初期値
        int random = 0;
        int random1 = 0;
        int random2 = 0;
         public int lovePointchange;

        // Use this for initialization
        void Start()
        {
            this.text = GameObject.Find("koukando");
            this.infomation = GameObject.Find("infomation");
            this.infomation.GetComponent<Text>().color = new Color(1, 1, 1, 0);
            this.textbox = GameObject.Find("textbox");
            this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }

        // Update is called once per frame
        void Update()
        {
            this.text.GetComponent<Text>().text =
                "好感度" + lovePoint;//好感度表示
        }
        public void koukandoUp()
        {
            this.random = Random.Range(0, 6);
            if (this.random >= 0 && this.random < 3)//2分の1の確率で好感度を10増やす
            {
                this.random = 0;
                this.lovePointchange += 10;
                this.lovePoint += this.lovePointchange;
                this.infomation.GetComponent<Text>().color = new Color(1, 1, 1, 1);
                this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                this.infomation.GetComponent<Text>().text =
                    "迷子の子供を交番まで案内した。\n好感度が"+lovePointchange+"増加した！";
            }
            else if (this.random >= 3 && this.random < 5)//3分の1の確率で好感度を15増やす
            {
                this.random = 0;
                lovePointchange += 15;
                this.lovePoint += this.lovePointchange;
                this.infomation.GetComponent<Text>().color = new Color(1, 1, 1, 1);
                this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                this.infomation.GetComponent<Text>().text =
                    "困っているおばあちゃんの荷物を持ってあげた。\n好感度が"+lovePointchange+"増加した！";
            }
            else if (this.random >= 5 && this.random < 6)//6分の1の確率で好感度を20増やす
            {
                this.random = 0;
                lovePointchange += 20;
                this.lovePoint += this.lovePointchange;
                this.infomation.GetComponent<Text>().color = new Color(1, 1, 1, 1);
                this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                this.infomation.GetComponent<Text>().text =
                    "ボランティア活動の参加してごみ拾いをした。\n好感度が"+lovePointchange+"増加した！";
            }
            lovePointchange = 0;
            //ここからプレイヤーの行動選択UIをいじるメソッドを呼ぶ

        }
        public void koukandoDown()
        {
            this.random1 = Random.Range(0, 6);
            if (this.random1 >= 0 && this.random1 < 3)//2分の1の確率で好感度を10減らす
            {
                this.random1 = 0;
                lovePointchange += 10;
                this.lovePoint -= this.lovePointchange;
                this.infomation.GetComponent<Text>().color = new Color(1, 1, 1, 1);
                this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                this.infomation.GetComponent<Text>().text =
                    "迷子の子供がいたが面倒だったので無視した。\n好感度が"+lovePointchange+"減少した！";
            }
            else if (this.random1 >= 3 && this.random1 < 5)//3分の1の確率で好感度を15減らす
            {
                this.random1 = 0;
                lovePointchange += 15;
                this.lovePoint -= this.lovePointchange;
                this.infomation.GetComponent<Text>().color = new Color(1, 1, 1, 1);
                this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                this.infomation.GetComponent<Text>().text =
                    "ペットボトルをポイ捨てした。\n好感度が"+lovePointchange+"減少した！";
            }
            else if (this.random1 >= 5 && this.random1 < 6)//6分の1の確率で好感度を20減らす
            {
                this.random1 = 0;
                lovePointchange += 20;
                this.lovePoint -= this.lovePointchange;
                this.infomation.GetComponent<Text>().color = new Color(1, 1, 1, 1);
                this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                this.infomation.GetComponent<Text>().text =
                    "ながら歩きしながら信号無視した。\n好感度が"+lovePointchange+"減少した！";
            }
            lovePointchange = 0;
            //ここからプレイヤーの行動選択UIをいじるメソッドを呼ぶ
        }
        public void ring()
        {
            lovePoint += 100;
            this.infomation.GetComponent<Text>().text =
                 "指輪を取り戻すことが出来た！";
        }
        //ここからプレイヤーの行動選択UIをいじるメソッドを呼ぶ
        
        public void flower()
        {
            lovePoint += 50;
            this.infomation.GetComponent<Text>().text =
                "花束を手に入れた！";
        }
        //ここからプレイヤーの行動選択UIをいじるメソッドを呼ぶ
        public void hatena()
        {
            random2 = Random.Range(0, 3);
            lovePoint += 50;
            if (this.random2 >= 0 && this.random2 < 1)
            {
                this.infomation.GetComponent<Text>().text =//テキスト表示
                              "テディベアを手に入れた！！";
            }
            if (this.random2 >= 1 && this.random2 < 2)
            {
                this.infomation.GetComponent<Text>().text =//テキスト表示
                             "王道少女漫画を手に入れた！！";
            }
            if (this.random2 >= 2)
            {
                this.infomation.GetComponent<Text>().text =//テキスト表示
                            "乙女ゲームを手に入れた！！";
            }

        }
        //ここからプレイヤーの行動選択UIをいじるメソッドを呼ぶ
    }
}
