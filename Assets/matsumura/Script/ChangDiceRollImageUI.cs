using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using matsumura.ChangDiceUI;

public class ChangDiceRollImageUI : MonoBehaviour {

    //インスペクタ上から画像をいれる
    public Sprite[] DiceImages;

    //毎フレーム画像の更新が起きないようにするための変数
    int SuppressionNum = 0;

	// Update is called once per frame
	void Update () {
        //UIDiceNumの数が変わったかどうか、UIDiceNumの数がオーバーしていないかどうか
        if (SuppressionNum != ChangDiceRollTextUI.UIDiceNum && ChangDiceRollTextUI.UIDiceNum != 7)
        {
            //数の変更の反映
            SuppressionNum = ChangDiceRollTextUI.UIDiceNum;
            //イメージへ反映
            gameObject.GetComponent<Image>().sprite = DiceImages[ChangDiceRollTextUI.UIDiceNum - 1];
        }
	}
}
