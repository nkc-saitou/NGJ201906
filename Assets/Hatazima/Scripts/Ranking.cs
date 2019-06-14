using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public RankingData data;

    public GameObject Rank1_object = null;// Textオブジェクト
    public GameObject Rank2_object = null;
    public GameObject Rank3_object = null;
    public GameObject Rank4_object = null;
    public GameObject Rank5_object = null;

    public float RankText1 = 0; // ランキング表示Text
    public float RankText2 = 0;
    public float RankText3 = 0;
    public float RankText4 = 0;
    public float RankText5 = 0;
    public float hozon1 = 0;
    public float hozon2 = 0;

    public float lovePoint = 999;


    void Start ()
    {
        lovePoint = LovePoint.lovePoint; //ここで好感度を受け取る

        if (RankText5 < lovePoint)
        {
            hozon1 = RankText5;
            RankText5 = lovePoint;
        }

        if (RankText4 < RankText5)
        {
            hozon2 = RankText4;
            RankText4 = RankText5;
            RankText5 = hozon1;
        }

        if(RankText3 < RankText4)
        {
            hozon1 = RankText3;
            RankText3 = RankText4;
            RankText4 = hozon2;
        }

        if(RankText2 < RankText3)
        {
            hozon2 = RankText2;
            RankText2 = RankText3;
            RankText3 = hozon1;
        }

        if(RankText1 < RankText2)
        {
            hozon1 = RankText1;
            RankText1 = RankText2;
            RankText2 = hozon2;
        }

        
        Text Rank1_Text = Rank1_object.GetComponent<Text>();
        Rank1_Text.text = "" + (RankText1);

        Text Rank2_Text = Rank2_object.GetComponent<Text>();
        Rank2_Text.text = "" + (RankText2);

        Text Rank3_Text = Rank3_object.GetComponent<Text>();
        Rank3_Text.text = "" + (RankText3);

        Text Rank4_Text = Rank4_object.GetComponent<Text>();
        Rank4_Text.text = "" + (RankText4);

        Text Rank5_Text = Rank5_object.GetComponent<Text>();
        Rank5_Text.text = "" + (RankText5);

        SetData();

    }

    /// <summary>
    /// ScriptableObjectにデータを追加
    /// </summary>
    void SetData()
    {
        data.rankingLis.Clear();

        data.rankingLis.Add(RankText1);
        data.rankingLis.Add(RankText2);
        data.rankingLis.Add(RankText3);
        data.rankingLis.Add(RankText4);
        data.rankingLis.Add(RankText5);
    }
	
	void Update ()
    {
		
	}
}
