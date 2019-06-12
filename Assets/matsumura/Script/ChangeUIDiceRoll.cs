using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace matsumura.PlayerButton
{
    public class ChangeUIDiceRoll : MonoBehaviour
    {

        ButtonInformation buttonInformation;

        // Use this for initialization
        void Start()
        {
            buttonInformation = GetComponent<ButtonInformation>();
        }

        public void ChangeUIDice()
        {
            ButtonInformation.ButtonState = 1;
            
            buttonInformation.DiceButton.transform.
                GetChild(0).GetComponent<Text>().text = "振る";
            buttonInformation.ItemButton.gameObject.SetActive(false);
            buttonInformation.LookButton.transform.
                GetChild(0).GetComponent<Text>().text = "戻る";
        }
    }
}

