using matsumura.PlayerAction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using matsumura.PlayerButton;

namespace matsumura.PlayerMove
{
    public class PlayerMoveDiceRoll : MonoBehaviour
    {
        public ChangeUIDiceRoll roll;
        public ChangUIBackBehaviorSelection back;

        //DiceButtonを押した際の分岐
        public void OnClickDice()
        {
            if (ButtonInformation.ButtonState == 0)
            {
                roll.ChangeUIDice();
            }
            else
            {
                back.ChangUIBack();
            }
        }

        // Use this for initialization
        void Start()
        {
            roll = transform.parent.GetComponent<ChangeUIDiceRoll>();
            back = transform.parent.GetComponent<ChangUIBackBehaviorSelection>();
        }
    }
}
