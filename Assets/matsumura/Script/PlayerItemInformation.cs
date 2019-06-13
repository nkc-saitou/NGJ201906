using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace matsumura.PLayerItem
{
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

        //どのボタンがどのアイテムかをイメージで分かりやすく
        GameObject playerHaveItemA;
        GameObject playerHaveItemB;
        GameObject playerHaveItemC;
        GameObject playerHaveItemD;
        GameObject playerHaveItemE;
        GameObject playerHaveItemF;

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

        // Use this for initialization
        void Start()
        {
            //各イメージの紐づけ
            playerHaveItemA = transform.Find("PlayerHaveItemA").gameObject;
            playerHaveItemB = transform.Find("PlayerHaveItemB").gameObject;
            playerHaveItemC = transform.Find("PlayerHaveItemC").gameObject;
            playerHaveItemD = transform.Find("PlayerHaveItemD").gameObject;
            playerHaveItemE = transform.Find("PlayerHaveItemE").gameObject;
            playerHaveItemF = transform.Find("PlayerHaveItemF").gameObject;
        }

    }
}
