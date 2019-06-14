using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using matsumura.PLayerItem;
using matsumura.PlayerButton;
using matsumura.DiceRoll;

public class ChangeUIItemDecide : MonoBehaviour {

    //ButtonInformationをいれる変数
    ButtonInformation buttonInformation;
    //PlayerItemInformationをいれる変数
    PlayerItemInformation playerItemInformation;

    //forで処理するため、配列にイメージの情報をまとめる
    GameObject[] PlayerHaveItem = new GameObject[6];
    //forで処理するため、配列にボタンの情報をまとめる
    GameObject[] ItemSlot = new GameObject[6];

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

        //配列にボタンの情報を写す
        ItemSlot[0] = buttonInformation.ItemSlotA;
        ItemSlot[1] = buttonInformation.ItemSlotB;
        ItemSlot[2] = buttonInformation.ItemSlotC;
        ItemSlot[3] = buttonInformation.ItemSlotD;
        ItemSlot[4] = buttonInformation.ItemSlotE;
        ItemSlot[5] = buttonInformation.ItemSlotF;

        //プレイヤーの情報取得

    }

    // Update is called once per frame
    public void ChangeUIItemChoiceDecide(int buttonNum) {

        //どのUIに変わったかをわかるように値を代入
        //2はアイテムの使用を選択をした場合のUI
        ButtonInformation.buttonState = 5;

        //DiceButtonを非活性化
        buttonInformation.DiceButton.gameObject.SetActive(true);
        //DiceButtonの子クラスのテキストを変更
        buttonInformation.DiceButton.transform.
            GetChild(0).GetComponent<Text>().text = "はい";
        //ItemButtonを非活性化
        buttonInformation.ItemButton.gameObject.SetActive(false);
        //LookButtonの子クラスのテキストを変更
        buttonInformation.LookButton.transform.
            GetChild(0).GetComponent<Text>().text = "いいえ";

        //UseItemに画像を入れる
        playerItemInformation.UseItem.GetComponent<Image>().sprite =
            playerItemInformation.ItemImages[a[buttonNum]];

        //UseItemが見えるようにする
        playerItemInformation.UseItem.GetComponent<Image>().color = new Color(1, 1, 1, 1);

        //アイテムによってテキストを変更
        if (a[buttonNum] == (int)ItemType.Car)
        {
            DiceRollInformation.itemMoveNum = 8;
            playerItemInformation.GameText.GetComponent<Text>().text = 
                "8マス固定で進みます\nこのアイテムを使用しますか？";
        }
        else if (a[buttonNum] == (int)ItemType.Bicycle)
        {
            DiceRollInformation.itemMoveNum = 6;
            playerItemInformation.GameText.GetComponent<Text>().text =
                "6マス固定で進みます\nこのアイテムを使用しますか？";
        }
        else if (a[buttonNum] == (int)ItemType.Skateboard)
        {
            DiceRollInformation.itemMoveNum = 4;
            playerItemInformation.GameText.GetComponent<Text>().text =
                "4マス固定で進みます\nこのアイテムを使用しますか？";
        }
        else if (a[buttonNum] == (int)ItemType.Hopping)
        {
            DiceRollInformation.itemMoveNum = 1;
            playerItemInformation.GameText.GetComponent<Text>().text =
                "1マス固定で進みます\nこのアイテムを使用しますか？";
        }


        //各ボタンとイメージの処理
        for (int i = 0; i < PlayerHaveItem.Length; i++)
        {
            //α値を0にする
            PlayerHaveItem[i].GetComponent<Image>().color = new Color(1, 1, 1, 0);
            //空の画像を入れる
            PlayerHaveItem[i].GetComponent<Image>().sprite =
                playerItemInformation.ItemImages[(int)ItemType.None];
            //ボタンを非活性化
            if(a[i] != 0)
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
}
