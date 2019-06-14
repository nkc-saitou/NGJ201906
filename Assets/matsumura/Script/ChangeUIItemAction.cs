using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using matsumura.PLayerItem;

namespace matsumura.PlayerButton
{
    public class ChangeUIItemAction : MonoBehaviour
    {
        //ButtonInformationをいれる変数
        ButtonInformation buttonInformation;
        //PlayerItemInformationをいれる変数
        PlayerItemInformation playerItemInformation;

        //forで処理するため、配列にイメージの情報をまとめる
        GameObject[] PlayerHaveItem = new GameObject[6];
        //forで処理するため、配列にボタンの情報をまとめる
        GameObject[] ItemSlot = new GameObject[6];

        Saitou.Player.PlayerMove playerMove;

        //プレイヤーのアイテム情報をいれる変数(仮)
        int[] a = { 0, 1, 2, 3, 4, 0 };

        // Use this for initialization
        void Start()
        {
            //ButtonInformationのボタンを使うので変数にいれる
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

            Debug.Log(playerItemInformation.PlayerHaveItemA);

            //配列にボタンの情報を写す
            ItemSlot[0] = buttonInformation.ItemSlotA;
            ItemSlot[1] = buttonInformation.ItemSlotB;
            ItemSlot[2] = buttonInformation.ItemSlotC;
            ItemSlot[3] = buttonInformation.ItemSlotD;
            ItemSlot[4] = buttonInformation.ItemSlotE;
            ItemSlot[5] = buttonInformation.ItemSlotF;

            //プレイヤーの情報取得
            playerMove = FindObjectOfType<Saitou.Player.PlayerMove>();

        }

        public void ChangeUIItem()
        {
            //
            if (ButtonInformation.buttonState == 5)
            {
                playerItemInformation.UseItem.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            }

            //どのUIに変わったかをわかるように値を代入
            //2はアイテムの使用を選択をした場合のUI
            ButtonInformation.buttonState = 2;

            //
            playerItemInformation.GameText.GetComponent<Text>().text =
                "どのアイテムを使用しますか？";

            //DiceButtonを非活性化
            buttonInformation.DiceButton.gameObject.SetActive(false);
            //ItemButtonを非活性化
            buttonInformation.ItemButton.gameObject.SetActive(false);
            //LookButtonの子クラスのテキストを変更
            buttonInformation.LookButton.transform.
                GetChild(0).GetComponent<Text>().text = "戻る";

            //各ボタンとイメージの処理
            for(int i = 0; i < PlayerHaveItem.Length; i++)
            {
                //アイテムを持っているかどうか
                if(a[i] != (int)ItemType.None)
                {
                    Debug.Log(PlayerHaveItem[1]);

                    //アイテムの画像を入れる
                    PlayerHaveItem[i].GetComponent<Image>().sprite =
                        playerItemInformation.ItemImages[a[i]];
                    //α値を戻す
                    PlayerHaveItem[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    //ボタンを活性化
                    ItemSlot[i].SetActive(true);
                }
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
    }
}
