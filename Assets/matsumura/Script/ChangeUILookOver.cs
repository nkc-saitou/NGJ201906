using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace matsumura.PlayerButton
{
    public class ChangeUILookOver : MonoBehaviour
    {
        ButtonInformation buttonInformation;


        // Use this for initialization
        void Start()
        {
            buttonInformation = GetComponent<ButtonInformation>();
        }

        // Update is called once per frame
        public void ChangeUILook()
        {
            ButtonInformation.ButtonState = 3;

            buttonInformation.DiceButton.gameObject.SetActive(false);
            buttonInformation.ItemButton.gameObject.SetActive(false);
            buttonInformation.LookButton.transform.
                GetChild(0).GetComponent<Text>().text = "戻る";
        }
    }
}
