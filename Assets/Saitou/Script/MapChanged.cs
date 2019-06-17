using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace Saitou.UI {


	public class MapChanged : MonoBehaviour {

		public GameObject[] UiObjects;

        public GameObject uiText;

        [Header("メッセージログを表示するテキスト")]
        public Text infoText;
        [Header("テキストボックス")]
        public GameObject textBox;
        [Header("移動方向を指し示す矢印")]
        public GameObject moveDirArrow;

        public GameObject GameClearCanvas;

        [Header("ゲームクリア、ゲームオーバー")]
        public GameObject[] GameClearText;

        public GameObject itemBackGround;

        float time;

        public Text dayText;
        public Animator anim;

        public int turn;
        public int Turn
        {
            get { return turn; }
            private set { turn = value; }
        }
        
        /// <summary>
        /// お嬢様がいきなり出てくるかどうあk
        /// </summary>
        public bool IsPrincessResult { get; set; }

        matsumura.PlayerLook.PlayerLookOver lookOver;
        Player.PlayerMove move;
        Player.PlayerActionState state;

        void Start()
        {
            IsPrincessResult = false;
            move = FindObjectOfType<Player.PlayerMove>();
            lookOver = FindObjectOfType<matsumura.PlayerLook.PlayerLookOver>();

            lookOver.boxActive += (bool isActive) => { textBox.SetActive(isActive); };

            foreach (var ui in UiObjects)
            {
                ui.gameObject.SetActive(false);
            }

            ShowUi();
        }

        void Update()
        {
            if(state != move.PlayerState)
            {
                ChangeStateAction();
            }

            // 更新
            state = move.PlayerState;

            if (Turn == 0)
            {
                if(IsPrincessResult == false) GameClear(false);
                Turn--;
            }
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

            uiText.SetActive(true);

        }

        /// <summary>
        /// ゲームクリア時またはゲームオーバー時に呼ぶ
        /// </summary>
        /// <param name="isClear"></param>
        public void GameClear(bool isClear)
        {
            StartCoroutine(GameClearWaitTime(isClear));
        }

        /// <summary>
        /// 遅延処理
        /// </summary>
        /// <returns></returns>
        IEnumerator WaitTime()
        {
            yield return new WaitForSeconds(1.0f);

            dayText.text = Turn.ToString();
            anim.SetBool("DayText", true);

            yield return new WaitForSeconds(2.0f);

            infoText.text = "行動をクリックで選択してね";

            foreach (var ui in UiObjects)
            {
                ui.gameObject.SetActive(true);
            }

            anim.SetBool("DayText", false);

            AudioManager.Instance.PlayBGM("Main");
        }

        IEnumerator GameClearWaitTime(bool isClear)
        {
            GameClearCanvas.SetActive(true);

            yield return new WaitForSeconds(1.0f);

            if (isClear) GameClearText[0].SetActive(true);
            else GameClearText[1].SetActive(true);

            yield return new WaitForSeconds(1.0f);

            FadeManager.Instance.LoadScene("Result");
        }

        /// <summary>
        /// ターン
        /// </summary>
        public void TurnDown()
        {
            Turn--;
        }

        /// <summary>
        /// アイテムを見やすくするよう
        /// </summary>
        public void ItemBackGroundActive()
        {
            itemBackGround.SetActive(true);
        }

        /// <summary>
        /// アイテムの後ろのイメージを隠す
        /// </summary>
        public void ItemBackGroundHide()
        {
            itemBackGround.SetActive(false);
        }
    }
}
