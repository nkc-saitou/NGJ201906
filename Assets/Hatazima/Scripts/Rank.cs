using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{
    public GameObject Rank_object = null;// Textオブジェクト

    public float lovePoint = 0; // 好感度
    public string RankText = ""; // ランク表示Text

    public static int RP = 1; // ランクピクチャ

    public delegate void LovePointEventHandler();
    public event LovePointEventHandler eventHandler;

    // 最初の一回のみ
    bool isFirst = true;


    void Start ()
    {
        lovePoint = 0; // 好感度を0に戻す
        //lovePoint = GameDirector.lovePoint; //ここで好感度を受け取る

        // 好感度によりランクを変更する
        if (lovePoint > 199)
        {
            RankText = "S";
            Text Rank_Text = Rank_object.GetComponent<Text>();
            Rank_Text.text = RankText;
            RP = 1;
        }
        else if (lovePoint > 169)
        {
            RankText = "A";
            Text Rank_Text = Rank_object.GetComponent<Text>();
            Rank_Text.text = RankText;
            RP = 2;
        }
        else if (lovePoint > 139)
        {
            RankText = "B";
            Text Rank_Text = Rank_object.GetComponent<Text>();
            Rank_Text.text = RankText;
            RP = 2;
        }
        else if (lovePoint > 109)
        {
            RankText = "C";
            Text Rank_Text = Rank_object.GetComponent<Text>();
            Rank_Text.text = RankText;
            RP = 3;
        }
        else if (lovePoint > 79)
        {
            RankText = "D";
            Text Rank_Text = Rank_object.GetComponent<Text>();
            Rank_Text.text = RankText;
            RP = 3;
        }
        else
        {
            RankText = "E";
            Text Rank_Text = Rank_object.GetComponent<Text>();
            Rank_Text.text = RankText;
            RP = 4;
        }

    }
	
	void Update ()
    {
        if(eventHandler != null && isFirst)
        {
            eventHandler();
            isFirst = false;
        }
	}
}
