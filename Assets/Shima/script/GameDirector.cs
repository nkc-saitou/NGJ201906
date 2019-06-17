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
        int lovePointchange;

        // showUI
	    Saitou.UI.MapChanged mapChanged;

        // Use this for initialization
        void Start()
        {
            this.text = GameObject.Find("koukando");
            this.infomation = GameObject.Find("GameText");
            //this.infomation.GetComponent<Text>().color = new Color(1, 1, 1, 0);
            //this.textbox = GameObject.Find("textbox");
            //this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 0);

	        mapChanged = FindObjectOfType<Saitou.UI.MapChanged>();

            ScoreManager.Instance.ResetScore();
            // 初期値代入
            ScoreManager.Instance.AddScore(lovePoint);
        }

        // Update is called once per frame
        void Update()
        {
            this.text.GetComponent<Text>().text =
                "好感度" + ScoreManager.Instance.Score;//好感度表示
        }
        public void koukandoUp()
        {
            AudioManager.Instance.PlayBGM("Blue");
            this.random = Random.Range(0, 6);
            if (this.random >= 0 && this.random < 3)//2分の1の確率で好感度を10増やす
            {
                this.random = 0;
                this.lovePointchange += 10;
                //this.lovePoint += this.lovePointchange;
                //this.infomation.GetComponent<Text>().color = new Color(1, 1, 1, 1);
                //this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                this.infomation.GetComponent<Text>().text =
                    "迷子の子供を交番まで案内した！\n好感度が" + lovePointchange + "増加した！";
            }
            else if (this.random >= 3 && this.random < 5)//3分の1の確率で好感度を15増やす
            {
                this.random = 0;
                lovePointchange += 15;
                //this.lovePoint += this.lovePointchange;
                //this.infomation.GetComponent<Text>().color = new Color(1, 1, 1, 1);
                //this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                this.infomation.GetComponent<Text>().text =
                   "困っているおばあちゃんの荷物を持ってあげた！\n好感度が" + lovePointchange + "増加した！";
            }
            else if (this.random >= 5 && this.random < 6)//6分の1の確率で好感度を20増やす
            {
                this.random = 0;
                lovePointchange += 20;
                //this.lovePoint += this.lovePointchange;
                //this.infomation.GetComponent<Text>().color = new Color(1, 1, 1, 1);
                //this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                this.infomation.GetComponent<Text>().text =
                   "ボランティア活動に参加してゴミ拾いをした！\n好感度が" + lovePointchange + "増加した！";
            }
            ScoreManager.Instance.AddScore(lovePointchange);
            lovePointchange = 0;
            //ここからプレイヤーの行動選択UIをいじるメソッドを呼ぶ
            mapChanged.ShowUi();
        }
        public void koukandoDown()
        {
            AudioManager.Instance.PlayBGM("Red");
            this.random1 = Random.Range(0, 6);
            if (this.random1 >= 0 && this.random1 < 3)//2分の1の確率で好感度を10減らす
            {
                this.random1 = 0;
                lovePointchange += 10;
                //this.lovePoint -= this.lovePointchange;
                //this.infomation.GetComponent<Text>().color = new Color(1, 1, 1, 1);
                //this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                this.infomation.GetComponent<Text>().text =
                   "迷子の子供がいたが面倒だったので無視した！\n好感度が" + lovePointchange + "減少した！";
            }
            else if (this.random1 >= 3 && this.random1 < 5)//3分の1の確率で好感度を15減らす
            {
                this.random1 = 0;
                lovePointchange += 15;
                //this.lovePoint -= this.lovePointchange;
                //this.infomation.GetComponent<Text>().color = new Color(1, 1, 1, 1);
                //this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                this.infomation.GetComponent<Text>().text =
                 "ペットボトルをポイ捨てした！\n好感度が" + lovePointchange + "減少した！";
            }
            else if (this.random1 >= 5 && this.random1 < 6)//6分の1の確率で好感度を20減らす
            {
                this.random1 = 0;
                lovePointchange += 20;
                //this.lovePoint -= this.lovePointchange;
                //this.infomation.GetComponent<Text>().color = new Color(1, 1, 1, 1);
                //this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                this.infomation.GetComponent<Text>().text =
                 "ながら歩きしながら信号無視した！\n好感度が" + lovePointchange + "減少した！";
            }
            ScoreManager.Instance.AddScore(-lovePointchange);
            this.lovePointchange = 0;
            //ここからプレイヤーの行動選択UIをいじるメソッドを呼ぶ
            mapChanged.ShowUi();
        }
        public void ring(bool isFirst)
        {
            if (isFirst)
            {
                AudioManager.Instance.PlaySE("trumpet1");
                lovePoint += 100;
                ScoreManager.Instance.AddScore(lovePoint);
            }
            //ここからプレイヤーの行動選択UIをいじるメソッドを呼ぶ
            mapChanged.ShowUi();
        }
        public void flower(bool isFirst)
        {
            if (isFirst)
            {
                AudioManager.Instance.PlaySE("trumpet1");
                lovePoint += 150;
                ScoreManager.Instance.AddScore(lovePoint);
            }
            //ここからプレイヤーの行動選択UIをいじるメソッドを呼ぶ
            mapChanged.ShowUi();
        }
        public void hatena(bool isFirst)
        {
            if (isFirst)
            {
                AudioManager.Instance.PlaySE("trumpet2");
                lovePoint += 200;
                ScoreManager.Instance.AddScore(lovePoint);
            }
            //ここからプレイヤーの行動選択UIをいじるメソッドを呼ぶ
            mapChanged.ShowUi();
        }
        public void taxi()
        {
            mapChanged.Taxi();
            this.infomation.GetComponent<Text>().text =
                "タクシーを捕まえた！\n　移動できるマスが増えた！";

            //mapChanged.ShowUi();
        }
    }
}
