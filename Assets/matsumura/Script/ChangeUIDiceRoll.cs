using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace matsumura.PlayerButton
{
    public class ChangeUIDiceRoll : MonoBehaviour
    {
        //ButtonInformationをいれる変数
        ButtonInformation buttonInformation;

        // Use this for initialization
        void Start()
        {
            //ButtonInformationの変数を使うためにこのクラスの変数にいれる
            buttonInformation = GetComponent<ButtonInformation>();
        }

        public void ChangeUIDice()
        {
            //どのUIに変わったかをわかるように値を代入
            //1はサイコロをふる選択をした場合のUI
            ButtonInformation.ButtonState = 1;

            //DiceButtonの子クラスのテキストを変更
            buttonInformation.DiceButton.transform.
                GetChild(0).GetComponent<Text>().text = "振る";
            //ItemButtonを非活性化
            buttonInformation.ItemButton.gameObject.SetActive(false);
            //LookButtonの子クラスのテキストを変更
            buttonInformation.LookButton.transform.
                GetChild(0).GetComponent<Text>().text = "戻る";
        }
    }
}

