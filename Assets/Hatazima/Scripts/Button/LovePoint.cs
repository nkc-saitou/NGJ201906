using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LovePoint : MonoBehaviour
{
    public GameObject lovePoint_object = null;// Textオブジェクト

    public float lovePoint = 0; // 好感度

    void Start ()
    {
        lovePoint = 0; // 好感度を0に戻す
        //lovePoint = GameDirector.lovePoint; //ここで好感度を受け取る

        Text lovePoint_Text = lovePoint_object.GetComponent<Text>();
        lovePoint_Text.text = "" + (lovePoint);
    }

    void Update ()
    {
		
	}
}
