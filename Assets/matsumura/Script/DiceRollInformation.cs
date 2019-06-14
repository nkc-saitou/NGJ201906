using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace matsumura.DiceRoll
{

    public class DiceRollInformation : MonoBehaviour
    {
        //プレイヤーがいくつ進むかを入れる変数
        static public int PlayerMoveNum;

        //サイコロを振る演出のイメージ部分
        GameObject changDiceRollImage;

        //サイコロを振る演出のテキスト部分
        GameObject changDiceRollText;

        //changDiceRollImageの取得と書き換えの情報経由用
        public GameObject ChangDiceRollImage
        {
            get { return changDiceRollImage; }
            set { changDiceRollImage = value; }
        }

        //changDiceRollTextの取得と書き換えの情報経由用
        public GameObject ChangDiceRollText
        {
            get { return changDiceRollText; }
            set { changDiceRollText = value; }
        }

        // Use this for initialization
        void Awake()
        {
            //テキストとイメージの紐づけ
            changDiceRollImage = transform.Find("ChangDiceRollImage").gameObject;
            changDiceRollText = transform.Find("ChangDiceRollText").gameObject;
        }
    }
}
