using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace matsumura.PlayerButton
{
    public class ChangUIBackBehaviorSelection : MonoBehaviour
    {

        ButtonInformation buttonInformation;

        // Use this for initialization
        void Start()
        {
            buttonInformation = GetComponent<ButtonInformation>();
        }

        // Update is called once per frame
        public void ChangUIBack()
        {
            if(ButtonInformation.ButtonState == 1)
            {
                buttonInformation.DiceButton.transform.
                GetChild(0).GetComponent<Text>().text = "サイコロ";
            }
            else
            {
                buttonInformation.DiceButton.gameObject.SetActive(true);
            }
            
            buttonInformation.ItemButton.gameObject.SetActive(true);
            buttonInformation.LookButton.transform.
                GetChild(0).GetComponent<Text>().text = "見渡す";

            ButtonInformation.ButtonState = 0;
        }
    }
}
