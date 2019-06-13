using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace matsumura.PlayerButton
{
    public class ChangUIBackBehaviorSelection : MonoBehaviour
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
        public void ChangUIBack()
        {
            if(ButtonInformation.ButtonState == 1)
            {
                //DiceButtonの子クラスのテキストを変更
                buttonInformation.DiceButton.transform.
                GetChild(0).GetComponent<Text>().text = "サイコロ";
            }
            else
            {
                //DiceButtonを活性化
                buttonInformation.DiceButton.gameObject.SetActive(true);
            }
            //ItemButtonを活性化
            buttonInformation.ItemButton.gameObject.SetActive(true);
            //LookButtonの子クラスのテキストを変更
            buttonInformation.LookButton.transform.
                GetChild(0).GetComponent<Text>().text = "見渡す";

            //どのUIに変わったかをわかるように値を代入
            //0は行動選択のUI(初期画面)
            ButtonInformation.ButtonState = 0;
        }
    }
}
