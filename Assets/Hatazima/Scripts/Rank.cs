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
        AudioManager.Instance.FadeOutBGM();

        //lovePoint = GameDirector.lovePoint; //ここで好感度を受け取る
        lovePoint = ScoreManager.Instance.Score;

        // 好感度によりランクを変更する
        if (lovePoint > 900)
        {
            RankText = "S";
            Text Rank_Text = Rank_object.GetComponent<Text>();
            Rank_Text.text = RankText;
            RP = 1;
        }
        else if (lovePoint > 600)
        {
            RankText = "A";
            Text Rank_Text = Rank_object.GetComponent<Text>();
            Rank_Text.text = RankText;
            RP = 2;
        }
        else if (lovePoint > 500)
        {
            RankText = "B";
            Text Rank_Text = Rank_object.GetComponent<Text>();
            Rank_Text.text = RankText;
            RP = 2;
        }
        else if (lovePoint > 400)
        {
            RankText = "C";
            Text Rank_Text = Rank_object.GetComponent<Text>();
            Rank_Text.text = RankText;
            RP = 3;
        }
        else if (lovePoint > 300)
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
        StartCoroutine(WaitTime());
    }
	
	void Update ()
    {
        if(eventHandler != null && isFirst)
        {
            eventHandler();
            isFirst = false;
        }
	}

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(10.5f);

        AudioManager.Instance.PlayBGM("Result");
    }
}
