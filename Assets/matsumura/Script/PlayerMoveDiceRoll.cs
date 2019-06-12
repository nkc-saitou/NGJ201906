using matsumura.PlayerAction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using matsumura.PlayerButton;

namespace matsumura.PlayerMove
{
    public class PlayerMoveDiceRoll : MonoBehaviour
    {
        public ChangeUIDiceRoll roll;

        public GameObject DiceButton; //ダイスを振るを選べるボタン
        public GameObject ItemButton; //アイテムを使うを選べるボタン
        public GameObject LookButton; //マップを見渡すを選べるボタン

        public int ButtonState = 0; //ボタンの現在の状態

        //DiceButtonを押した際の分岐
        public void OnClickDice()
        {
            if(ButtonState == 0)
            {
                Debug.Log(1);
                roll.ChangeUIDice();
            }
        }

        // Use this for initialization
        void Start()
        {
            roll = transform.parent.GetComponent<ChangeUIDiceRoll>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
