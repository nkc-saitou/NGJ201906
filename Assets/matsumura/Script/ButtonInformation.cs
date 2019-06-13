using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace matsumura.PlayerButton
{
    public class ButtonInformation : MonoBehaviour
    {
        GameObject diceButton; //ダイスを振るを選べるボタン

        GameObject itemButton; //アイテムを使うを選べるボタン

        GameObject lookButton; //マップを見渡すを選べるボタン

        //diceButtunの取得と書き換えの情報経由用
        public GameObject DiceButton
        {
            get { return diceButton; }
            set { diceButton = value; }
        }

        //itemButtunの取得と書き換えの情報経由用
        public GameObject ItemButton
        {
            get { return itemButton; }
            set { itemButton = value; }
        }

        //lookButtunの取得と書き換えの情報経由用
        public GameObject LookButton
        {
            get { return lookButton; }
            set { lookButton = value; }
        }

        public static int ButtonState = 0; //ボタンの現在の状態

        // Use this for initialization
        void Start()
        {
            //各ボタンの紐づけ
            diceButton = transform.Find("DiceButton").gameObject;
            itemButton = transform.Find("ItemButton").gameObject;
            lookButton = transform.Find("LookButton").gameObject;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
