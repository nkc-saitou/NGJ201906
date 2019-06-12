using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using matsumura.PlayerButton;

namespace matsumura.PlayerLook
{
    public class PlayerLookOver : MonoBehaviour
    {
        public ChangeUILookOver roll;
        public ChangUIBackBehaviorSelection back;


        //LookButtonを押した際の分岐
        public void OnClickLookOver()
        {
            if (ButtonInformation.ButtonState == 0)
            {
                roll.ChangeUILook();
            }
            else
            {
                back.ChangUIBack();
            }
        }

        // Use this for initialization
        void Start()
        {
            roll = transform.parent.GetComponent<ChangeUILookOver>();
            back = transform.parent.GetComponent<ChangUIBackBehaviorSelection>();
        }
    }
}
