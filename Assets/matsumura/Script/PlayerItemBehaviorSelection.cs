using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using matsumura.PlayerButton;

namespace matsumura.PlayerUesItem
{
    public class PlayerItemBehaviorSelection : MonoBehaviour
    {
        public ChangeUIItemAction roll;
        public ChangUIBackBehaviorSelection back;

        //ItemButtonを押した際の分岐
        public void OnClickItem()
        {
            if (ButtonInformation.ButtonState == 0)
            {
                roll.ChangeUIItem();
            }
            else
            {
                back.ChangUIBack();
            }
        }

        // Use this for initialization
        void Start()
        {
            roll = transform.parent.GetComponent<ChangeUIItemAction>();
            back = transform.parent.GetComponent<ChangUIBackBehaviorSelection>();
        }
    }
}
