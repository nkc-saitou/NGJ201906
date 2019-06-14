using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace matsumura.ChangDiceUI
{

    public class ChangDiceRollTextUI : MonoBehaviour
    {
        //何フレームに一度画像とテキストを変えるかをカウントする変数
        int ChangTextflameCount = 4;
        //今の画像とテキストの数
        static public int UIDiceNum = 0;

        // Update is called once per frame
        void Update()
        {
            //カウント増加
            ChangTextflameCount++;

            //5フレームに一度変更
            if (ChangTextflameCount == 5)
            {
                //カウントを戻す
                ChangTextflameCount = 0;
                //画像とテキストの変更のための数増加
                UIDiceNum++;

                //増加しすぎた場合の処理
                if (UIDiceNum == 7)
                {
                    UIDiceNum = 1;
                }

                //テキストに反映
                gameObject.GetComponent<Text>().text = "" + UIDiceNum;
            }
        }
    }
}
