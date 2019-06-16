using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace Saitou.UI {


	public class MapChanged : MonoBehaviour {

		public GameObject[] UiObjects;

        [Header("メッセージログを表示するテキスト")]
        public Text infoText;
        [Header("テキストボックス")]
        public GameObject textBox;
        [Header("移動方向を指し示す矢印")]
        public GameObject moveDirArrow;

        matsumura.PlayerLook.PlayerLookOver lookOver;
        Player.PlayerMove move;
        Player.PlayerActionState state;

        void Start()
        {
            move = FindObjectOfType<Player.PlayerMove>();
            lookOver = FindObjectOfType<matsumura.PlayerLook.PlayerLookOver>();

            lookOver.boxActive += (bool isActive) => { textBox.SetActive(isActive); };
        }

        void Update()
        {
            if(state != move.PlayerState)
            {
                ChangeStateAction();
            }

            // 更新
            state = move.PlayerState;
        }

        /// <summary>
        /// ステートが変わったら
        /// </summary>
        void ChangeStateAction()
        {
            if (move.PlayerState == Player.PlayerActionState.move)
            {
                moveDirArrow.SetActive(true);
                textBox.SetActive(false);
            }
            else
            {
                moveDirArrow.SetActive(false);
                textBox.SetActive(true);
            }
        }

        /// <summary>
        /// ui
        /// </summary>
        public void ShowUi() {

            StartCoroutine(WaitTime());

            foreach (var ui in UiObjects) {
				ui.gameObject.SetActive(true);
			}
		}

        /// <summary>
        /// 遅延処理
        /// </summary>
        /// <returns></returns>
        IEnumerator WaitTime()
        {
            yield return new WaitForSeconds(1.0f);

            infoText.text = "行動をクリックで選択してね";
        }
	}
}
