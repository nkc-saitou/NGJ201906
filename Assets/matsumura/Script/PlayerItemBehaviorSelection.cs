using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using matsumura.PlayerButton;

namespace matsumura.PlayerUesItem
{
    public class PlayerItemBehaviorSelection : MonoBehaviour
    {
        //ChangeUIItemActionをいれる変数
        public ChangeUIItemAction roll;

        //ItemButtonを押した際の分岐
        public void OnClickItemAction()
        {
            //アイテムを使用することを選んだ場合のUI処理
            roll.ChangeUIItem();
        }

        // Use this for initialization
        void Start()
        {
            //クラスを変数の中に入れる(親クラスからの参照)
            roll = transform.parent.GetComponent<ChangeUIItemAction>();
        }
    }
}
