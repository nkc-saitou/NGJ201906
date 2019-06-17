using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using matsumura.PlayerButton;
using matsumura.PLayerItem;

namespace matsumura.DiceRoll
{
    public class ChangeUIPlayerBehaviorSelectionDice : MonoBehaviour {

        //ButtonInformationをいれる変数
        DiceRollInformation diceRollInformation;
        //PlayerItemInformationをいれる変数
        PlayerItemInformation playerItemInformation;
        //DiceRollInformationをいれる変数
        ButtonInformation buttonInformation;
        // プレイヤー
        Saitou.Player.PlayerMove move;

        // Use this for initialization
        void Start() {
            //ButtonInformationの変数を使うためにこのクラスの変数にいれる
            buttonInformation = GetComponent<ButtonInformation>();
            //PlayerItemInformationのイメージを使うので変数にいれる
            playerItemInformation = GetComponent<PlayerItemInformation>();
            //DiceRollInformationのイメージを使うので変数にいれる
            diceRollInformation = GetComponent<DiceRollInformation>();

            // プレイヤーの情報を取得
            move = FindObjectOfType<Saitou.Player.PlayerMove>();
        }

        public void ChangeUIDicePutOut(int playerMoveNum)
        {
            //サイコロを振る演出のON
            diceRollInformation.ChangDiceRollImage.gameObject.SetActive(false);
            diceRollInformation.ChangDiceRollText.gameObject.SetActive(false);

            //
            playerItemInformation.GameText.gameObject.SetActive(false);

            //
            ButtonInformation.buttonState = 0;

            //DiceButtonの子クラスのテキストを変更
            buttonInformation.DiceButton.transform.
                GetChild(0).GetComponent<Text>().text = "サイコロ";
            //DiceButtonを非活性化
            buttonInformation.DiceButton.gameObject.SetActive(false);
            //LookButtonの子クラスのテキストを変更
            buttonInformation.LookButton.transform.
                GetChild(0).GetComponent<Text>().text = "見渡す";
            //LookButtonを非活性化
            buttonInformation.LookButton.gameObject.SetActive(false);

            //移動の処理を呼ぶ
            move.GetMoveCount(playerMoveNum);
        }
    }
}
