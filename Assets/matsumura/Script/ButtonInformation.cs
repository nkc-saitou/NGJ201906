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

        //どのアイテムを使うかのボタン
        GameObject itemSlotA;
        GameObject itemSlotB;
        GameObject itemSlotC;
        GameObject itemSlotD;
        GameObject itemSlotE;
        GameObject itemSlotF;

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

        //どのアイテムを使うかのボタンの取得と書き換えの情報経由用
        public GameObject ItemSlotA
        {
            get { return itemSlotA; }
            set { itemSlotA = value; }
        }
        public GameObject ItemSlotB
        {
            get { return itemSlotB; }
            set { itemSlotB = value; }
        }
        public GameObject ItemSlotC
        {
            get { return itemSlotC; }
            set { itemSlotC = value; }
        }
        public GameObject ItemSlotD
        {
            get { return itemSlotD; }
            set { itemSlotD = value; }
        }
        public GameObject ItemSlotE
        {
            get { return itemSlotE; }
            set { itemSlotE = value; }
        }
        public GameObject ItemSlotF
        {
            get { return itemSlotF; }
            set { itemSlotF = value; }
        }

        public static int buttonState = 0; //ボタンの現在の状態

        // Use this for initialization
        void Start()
        {
            //各ボタンの紐づけ
            diceButton = transform.Find("DiceButton").gameObject;
            itemButton = transform.Find("ItemButton").gameObject;
            lookButton = transform.Find("LookButton").gameObject;
            itemSlotA = transform.Find("ItemSlotA").gameObject;
            itemSlotB = transform.Find("ItemSlotB").gameObject;
            itemSlotC = transform.Find("ItemSlotC").gameObject;
            itemSlotD = transform.Find("ItemSlotD").gameObject;
            itemSlotE = transform.Find("ItemSlotE").gameObject;
            itemSlotF = transform.Find("ItemSlotF").gameObject;
        }
    }
}
