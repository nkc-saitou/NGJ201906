using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using matsumura.PLayerItem;
using matsumura.DiceRoll;

namespace matsumura.PlayerButton
{
    public class ChangeUIDiceRoll : MonoBehaviour
    {
        //ButtonInformationをいれる変数
        ButtonInformation buttonInformation;
        //PlayerItemInformationをいれる変数
        PlayerItemInformation playerItemInformation;
        //DiceRollInformationをいれる変数
        DiceRollInformation diceRollInformation;

        // Use this for initialization
        void Start()
        {
            //ButtonInformationの変数を使うためにこのクラスの変数にいれる
            buttonInformation = GetComponent<ButtonInformation>();
            //PlayerItemInformationのイメージを使うので変数にいれる
            playerItemInformation = GetComponent<PlayerItemInformation>();
            //DiceRollInformationのイメージを使うので変数にいれる
            diceRollInformation = GetComponent<DiceRollInformation>();
        }

        public void ChangeUIDice()
        {
            //どのUIに変わったかをわかるように値を代入
            //1はサイコロをふる選択をした場合のUI
            ButtonInformation.buttonState = 1;

            //テキストの変更
            playerItemInformation.GameText.GetComponent<Text>().text =
                "サイコロを振って進むマスを決めよう！";

            //サイコロを振る演出のON
            diceRollInformation.ChangDiceRollImage.gameObject.SetActive(true);
            diceRollInformation.ChangDiceRollText.gameObject.SetActive(true);

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

