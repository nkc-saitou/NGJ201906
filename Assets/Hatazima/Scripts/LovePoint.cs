using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LovePoint : MonoBehaviour
{
    public GameObject lovePoint_object = null;// Textオブジェクト

    float lovePoint = 50; // 好感度

    void Start ()
    {
        lovePoint = ScoreManager.Instance.Score; //ここで好感度を受け取る

        Text lovePoint_Text = lovePoint_object.GetComponent<Text>();
        lovePoint_Text.text = "" + (lovePoint);
    }

    void Update ()
    {
		
	}
}
