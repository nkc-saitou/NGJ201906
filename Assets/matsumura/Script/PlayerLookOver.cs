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

        //ChangeUIItemActionをいれる変数
        public ChangeUIItemAction Item;

        //ChangUIBackBehaviorSelectionをいれる変数
        public ChangUIBackBehaviorSelection back;

        /// <summary>
        /// 見渡すときにTextBoxをActiveをfalseにするイベント
        /// </summary>
        /// <param name="isActive">falseにしたら非表示</param>
        public delegate void BoxActiveEventHandler(bool isActive);
        public event BoxActiveEventHandler boxActive;

        //LookButtonを押した際の分岐
        public void OnClickLookOver()
        {
            //ButtonStateの値によって分岐
            //0は初期数値
            if (ButtonInformation.buttonState == 0)
            {
                //マップを見渡すことを選んだ場合のUI処理
                roll.ChangeUILook();
                boxActive(false);
            }
            //5は最終決定画面から戻る場合
            else if(ButtonInformation.buttonState == 5)
            {
                //2番のUIに戻す(アイテム使用選択)
                Item.ChangeUIItem();
            }
            else
            {
                //行動選択のところに戻すUI処理
                back.ChangUIBack();
                boxActive(true);
            }
        }

        // Use this for initialization
        void Start()
        {
            //クラスを変数の中にいれる(親クラスからの参照)
            roll = transform.parent.GetComponent<ChangeUILookOver>();
            Item = transform.parent.GetComponent<ChangeUIItemAction>();
            back = transform.parent.GetComponent<ChangUIBackBehaviorSelection>();
        }
    }
}
