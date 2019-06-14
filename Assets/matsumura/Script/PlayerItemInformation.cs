using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace matsumura.PLayerItem
{
    //アイテムの数を型参照するときに使う
    public enum ItemType
    {
        None,
        Car,
        Bicycle,
        Skateboard,
        Hopping
    }
    public class PlayerItemInformation : MonoBehaviour
    {
        //インスペクタ上から画像をいれる
        public Sprite[] ItemImages;
        //インスペクタ上からゲームのテキスト(Information)
        public GameObject GameText;

        //どのボタンがどのアイテムかをイメージで分かりやすく
        GameObject playerHaveItemA;
        GameObject playerHaveItemB;
        GameObject playerHaveItemC;
        GameObject playerHaveItemD;
        GameObject playerHaveItemE;
        GameObject playerHaveItemF;

        //どんなアイテムを使うか分かりやすく
        GameObject useItem;

        //イメージの取得と書き換えの情報経由用
        public GameObject PlayerHaveItemA
        {
            get { return playerHaveItemA; }
            set { playerHaveItemA = value; }
        }
        public GameObject PlayerHaveItemB
        {
            get { return playerHaveItemB; }
            set { playerHaveItemB = value; }
        }
        public GameObject PlayerHaveItemC
        {
            get { return playerHaveItemC; }
            set { playerHaveItemC = value; }
        }
        public GameObject PlayerHaveItemD
        {
            get { return playerHaveItemD; }
            set { playerHaveItemD = value; }
        }
        public GameObject PlayerHaveItemE
        {
            get { return playerHaveItemE; }
            set { playerHaveItemE = value; }
        }
        public GameObject PlayerHaveItemF
        {
            get { return playerHaveItemF; }
            set { playerHaveItemF = value; }
        }

        //useItemの取得と書き換えの情報経由用
        public GameObject UseItem
        {
            get { return useItem; }
            set { useItem = value; }
        }

        // Use this for initialization
        void Awake()
        {
            //各イメージの紐づけ
            playerHaveItemA = transform.Find("PlayerHaveItemA").gameObject;
            playerHaveItemB = transform.Find("PlayerHaveItemB").gameObject;
            playerHaveItemC = transform.Find("PlayerHaveItemC").gameObject;
            playerHaveItemD = transform.Find("PlayerHaveItemD").gameObject;
            playerHaveItemE = transform.Find("PlayerHaveItemE").gameObject;
            playerHaveItemF = transform.Find("PlayerHaveItemF").gameObject;
            useItem = transform.Find("UseItem").gameObject;
        }

    }
}
