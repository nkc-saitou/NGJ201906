using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace matsumura.PlayerAction
{
    public class PlayerUseItemDecide : MonoBehaviour
    {
        //ChangeUIItemActionをいれる変数
        public ChangeUIItemDecide roll;

        // Use this for initialization
        public void OnClickItem(int buttonNum)
        {
            //アイテム使用の最終確認のUIに飛ばす
            roll.ChangeUIItemChoiceDecide(buttonNum);
        }

        // Update is called once per frame
        void Start()
        {
            //クラスを変数の中に入れる(親クラスからの参照)
            roll = transform.parent.GetComponent<ChangeUIItemDecide>();
        }
    }
}