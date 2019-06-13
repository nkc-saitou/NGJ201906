using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using matsumura.PlayerButton;

namespace matsumura.PlayerLook
{
    public class PlayerLookOver : MonoBehaviour
    {
        //ChangeUILookOverをいれる変数
        public ChangeUILookOver roll;
        //ChangUIBackBehaviorSelectionをいれる変数
        public ChangUIBackBehaviorSelection back;


        //LookButtonを押した際の分岐
        public void OnClickLookOver()
        {
            //ButtonStateの値によって分岐
            //0は初期数値
            if (ButtonInformation.buttonState == 0)
            {
                //マップを見渡すことを選んだ場合のUI処理
                roll.ChangeUILook();
            }
            else
            {
                //行動選択のところに戻すUI処理
                back.ChangUIBack();
            }
        }

        // Use this for initialization
        void Start()
        {
            //クラスを変数の中にいれる(親クラスからの参照)
            roll = transform.parent.GetComponent<ChangeUILookOver>();
            back = transform.parent.GetComponent<ChangUIBackBehaviorSelection>();
        }
    }
}
