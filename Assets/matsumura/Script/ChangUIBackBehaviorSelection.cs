using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using matsumura.PLayerItem;

namespace matsumura.PlayerButton
{
    public class ChangUIBackBehaviorSelection : MonoBehaviour
    {
        //ButtonInformationをいれる変数
        ButtonInformation buttonInformation;
        //PlayerItemInformationをいれる変数
        PlayerItemInformation playerItemInformation;

        //forで処理するため、配列にイメージの情報をまとめる
        GameObject[] PlayerHaveItem = new GameObject[6];
        //forで処理するため、配列にボタンの情報をまとめる
        GameObject[] ItemSlot = new GameObject[6];

        // Use this for initialization
        void Start()
        {
            //ButtonInformationの変数を使うためにこのクラスの変数にいれる
            buttonInformation = GetComponent<ButtonInformation>();
            //PlayerItemInformationのイメージを使うので変数にいれる
            playerItemInformation = GetComponent<PlayerItemInformation>();

            //配列にイメージを入れるところの情報を写す
            PlayerHaveItem[0] = playerItemInformation.PlayerHaveItemA;
            PlayerHaveItem[1] = playerItemInformation.PlayerHaveItemB;
            PlayerHaveItem[2] = playerItemInformation.PlayerHaveItemC;
            PlayerHaveItem[3] = playerItemInformation.PlayerHaveItemD;
            PlayerHaveItem[4] = playerItemInformation.PlayerHaveItemE;
            PlayerHaveItem[5] = playerItemInformation.PlayerHaveItemF;

            //配列にボタンの情報を写す
            ItemSlot[0] = buttonInformation.ItemSlotA;
            ItemSlot[1] = buttonInformation.ItemSlotB;
            ItemSlot[2] = buttonInformation.ItemSlotC;
            ItemSlot[3] = buttonInformation.ItemSlotD;
            ItemSlot[4] = buttonInformation.ItemSlotE;
            ItemSlot[5] = buttonInformation.ItemSlotF;
        }

        // Update is called once per frame
        public void ChangUIBack()
        {
            if(ButtonInformation.buttonState == 1)
            {
                //DiceButtonの子クラスのテキストを変更
                buttonInformation.DiceButton.transform.
                GetChild(0).GetComponent<Text>().text = "サイコロ";
            }
            else if(ButtonInformation.buttonState == 2)
            {
                //DiceButtonを活性化
                buttonInformation.DiceButton.gameObject.SetActive(true);

                //各ボタンとイメージの処理
                for (int i = 0; i < PlayerHaveItem.Length; i++)
                {
                    //α値を0にする
                    PlayerHaveItem[i].GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    //空の画像を入れる
                    PlayerHaveItem[i].GetComponent<Image>().sprite = 
                        playerItemInformation.ItemImages[(int)ItemType.None];
                    //ボタンを非活性化
                    ItemSlot[i].SetActive(false);
                }

                //各イメージの情報を元のところにわたす
                playerItemInformation.PlayerHaveItemA = PlayerHaveItem[0];
                playerItemInformation.PlayerHaveItemB = PlayerHaveItem[1];
                playerItemInformation.PlayerHaveItemC = PlayerHaveItem[2];
                playerItemInformation.PlayerHaveItemD = PlayerHaveItem[3];
                playerItemInformation.PlayerHaveItemE = PlayerHaveItem[4];
                playerItemInformation.PlayerHaveItemF = PlayerHaveItem[5];
                //各ボタンの情報を元のところにわたす
                buttonInformation.ItemSlotA = ItemSlot[0];
                buttonInformation.ItemSlotB = ItemSlot[1];
                buttonInformation.ItemSlotC = ItemSlot[2];
                buttonInformation.ItemSlotD = ItemSlot[3];
                buttonInformation.ItemSlotE = ItemSlot[4];
                buttonInformation.ItemSlotF = ItemSlot[5];
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
            ButtonInformation.buttonState = 0;
        }
    }
}
