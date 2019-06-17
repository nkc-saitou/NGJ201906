using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPicture : MonoBehaviour
{

    Rank rank;

    public GameObject RankPrefab1;  //プレハブになるもの
    public GameObject RankPrefab2;  
    public GameObject RankPrefab3;  
    public GameObject RankPrefab4;

    int RP = 1; //ランクピクチャ

    void Start ()
    {
        rank = GetComponent<Rank>();
        rank.eventHandler += () => SetLoveImage();
    }
	
	void Update ()
    {
		
	}

    /// <summary>
    /// LovePointに応じてイメージを変える
    /// </summary>
    void SetLoveImage()
    {
        RP = Rank.RP;
        //ランクによりイラストを変更
        switch (RP)
        {
            case 1:
                GameObject go1 = Instantiate(RankPrefab1) as GameObject;  //プレハブを作成する
                AudioManager.Instance.PlaySE("piano1");
                break;
            case 2:
                GameObject go2 = Instantiate(RankPrefab2) as GameObject;  //プレハブを作成する
                AudioManager.Instance.PlaySE("piano1");
                break;
            case 3:
                GameObject go3 = Instantiate(RankPrefab3) as GameObject;  //プレハブを作成する
                AudioManager.Instance.PlaySE("fate1");
                break;
            case 4:
                GameObject go4 = Instantiate(RankPrefab4) as GameObject;  //プレハブを作成する
                AudioManager.Instance.PlaySE("fate2");
                break;

        }
    }
}
