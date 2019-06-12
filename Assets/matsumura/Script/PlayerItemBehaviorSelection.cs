using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace matsumura.PlayerUesItem
{
    public class PlayerItemBehaviorSelection : MonoBehaviour
    {

        public GameObject DiceButton; //ダイスを振るを選べるボタン
        public GameObject ItemButton; //アイテムを使うを選べるボタン
        public GameObject LookButton; //マップを見渡すを選べるボタン

        public int ButtonState = 0; //ボタンの現在の状態

        //ItemButtonを押した際の分岐
        public void OnClickItem()
        {
            Debug.Log(2);
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
