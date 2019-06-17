using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using matsumura.PLayerItem;

namespace matsumura.PlayerButton
{
    public class ChangeUILookOver : MonoBehaviour
    {
        //ButtonInformationをいれる変数
        ButtonInformation buttonInformation;
        //PlayerItemInformationをいれる変数
        PlayerItemInformation playerItemInformation;


        // Use this for initialization
        void Start()
        {
            //ButtonInformationの変数を使うためにこのクラスの変数にいれる
            buttonInformation = GetComponent<ButtonInformation>();
            //PlayerItemInformationのイメージを使うので変数にいれる
            playerItemInformation = GetComponent<PlayerItemInformation>();
        }

        // Update is called once per frame
        public void ChangeUILook()
        {
            //どのUIに変わったかをわかるように値を代入
            //3はマップを見渡す選択をした場合のUI
            ButtonInformation.buttonState = 3;

            //テキストの変更
            playerItemInformation.GameText.GetComponent<Text>().text =
                "";

            //GameTextの非活性化


            //DiceButtonを非活性化
            buttonInformation.DiceButton.gameObject.SetActive(false);
            //ItemButtonを非活性化
            buttonInformation.ItemButton.gameObject.SetActive(false);
            //LookButtonの子クラスのテキストを変更
            buttonInformation.LookButton.transform.
                GetChild(0).GetComponent<Text>().text = "戻る";

            //見渡し用ボタンの活性化
            buttonInformation.RightButton.gameObject.SetActive(true);
            buttonInformation.LeftButton.gameObject.SetActive(true);
            buttonInformation.UpButton.gameObject.SetActive(true);
            buttonInformation.DownButton.gameObject.SetActive(true);
        }
    }
}
