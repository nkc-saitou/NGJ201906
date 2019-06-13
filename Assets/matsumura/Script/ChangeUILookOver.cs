using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace matsumura.PlayerButton
{
    public class ChangeUILookOver : MonoBehaviour
    {
        //ButtonInformationをいれる変数
        ButtonInformation buttonInformation;


        // Use this for initialization
        void Start()
        {
            //ButtonInformationの変数を使うためにこのクラスの変数にいれる
            buttonInformation = GetComponent<ButtonInformation>();
        }

        // Update is called once per frame
        public void ChangeUILook()
        {
            //どのUIに変わったかをわかるように値を代入
            //3はマップを見渡す選択をした場合のUI
            ButtonInformation.buttonState = 3;

            //DiceButtonを非活性化
            buttonInformation.DiceButton.gameObject.SetActive(false);
            //ItemButtonを非活性化
            buttonInformation.ItemButton.gameObject.SetActive(false);
            //LookButtonの子クラスのテキストを変更
            buttonInformation.LookButton.transform.
                GetChild(0).GetComponent<Text>().text = "戻る";
        }
    }
}
