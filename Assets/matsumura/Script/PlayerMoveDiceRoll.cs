using matsumura.PlayerAction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using matsumura.PlayerButton;

namespace matsumura.PlayerMove
{
    public class PlayerMoveDiceRoll : MonoBehaviour
    {
        //ChangeUIDiceRollをいれる変数
        public ChangeUIDiceRoll roll;
        //ChangUIBackBehaviorSelectionをいれる変数
        public ChangUIBackBehaviorSelection back;

        //DiceButtonを押した際の分岐
        public void OnClickDice()
        {
            //ButtonStateの値によって分岐
            //0は初期数値
            if (ButtonInformation.buttonState == 0)
            {
                //サイコロを振ることを選択した場合のUI処理
                roll.ChangeUIDice();
            }
            //1はサイコロを振る画面
            else if(ButtonInformation.buttonState == 1)
            {
                //サイコロ振った場合のUIと値の処理
                
            }
            //5はアイテム使用の最終確認画面
            else if(ButtonInformation.buttonState == 5)
            {
                //アイテムを使った際の値の処理

            }
        }

        // Use this for initialization
        void Start()
        {
            //クラスを変数の中に入れる(親クラスからの参照)
            roll = transform.parent.GetComponent<ChangeUIDiceRoll>();
            back = transform.parent.GetComponent<ChangUIBackBehaviorSelection>();
        }
    }
}
