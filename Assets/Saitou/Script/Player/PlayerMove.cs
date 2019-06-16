using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Saitou.Squares;
using UnityEngine.UI;
using System;
using Saitou.System;

namespace Saitou.Player
{
    public enum PlayerActionState
    {
        wait,
        move,
        squareAction,
        actionSelect,
    }

    public class PlayerMove : MonoBehaviour
    {
        public MapCreate create;

        [Header("south,west,east,north")]
        public Button[] button;

        public Text moveCountText;

        //所持アイテム
        [SerializeField] int[] haveItem;

        public int[] HaveItem
        {
            get { return haveItem; }
            set { haveItem = value; }
        }

        List<List<int>> mapData = new List<List<int>>();
        List<List<Transform>> mapPosLis = new List<List<Transform>>();
        List<List<SquareType>> squareLis = new List<List<SquareType>>();

		// 次に進むことが出来るマス
        List<Position> candidate = new List<Position>();

        Position startPos;
        Position goalPos;

        // 現在の位置
        Position nowPos;

        // ひとつ前の位置
        Position oneBeforePos;

        // 次の目的地
        Position nextPos;

        UI.MapChanged mapChanged;

        // 動ける数
        int moveCount = 0;

        public PlayerActionState PlayerState { get; private set; }

        /// <summary>
        /// MapCreateよりも遅く実行する
        /// </summary>
        /// <returns></returns>
        IEnumerator Start()
        {
            // 処理順の調整
            yield return new WaitForSeconds(0.1f);
            InitSetValue();

            NextSquare();

            PlayerState = PlayerActionState.actionSelect;

            mapChanged = FindObjectOfType<UI.MapChanged>();
        }

        /// <summary>
        /// マス効果発動
        /// </summary>
	    void ExecuteAction() {

		    if (PlayerState != PlayerActionState.squareAction) return;

		    var map = mapPosLis[nowPos.y][nowPos.x].gameObject.FindGameObjectInterface<ISquaresCall>();
            map.SquaresCall();
	    }

        /// <summary>
        /// ゴールにたどり着いたかどうかをチェック
        /// </summary>
        void CheckEnd()
        {
            if (goalPos.x == nowPos.x && goalPos.y == nowPos.y)
                FadeManager.Instance.LoadScene("Result");
        }

	    /// <summary>
        ///  値の初期化
        /// </summary>
        void InitSetValue()
        {
            startPos.x = create.StartPos.x;
            startPos.y = create.StartPos.y;

            oneBeforePos.x = 0;
            oneBeforePos.y = 0;

            goalPos.x = create.GoalPos.x;
            goalPos.y = create.GoalPos.y;

            nowPos.x = startPos.x;
            nowPos.y = startPos.y;

            mapData = create.MapData;
            mapPosLis = create.MapPosLis;
            squareLis = create.SquareLis;

            transform.position = mapPosLis[nowPos.y][nowPos.x].transform.localPosition;
        }

        /// <summary>
        /// 次の移動できるマス目を取得
        /// </summary>
        void NextSquare()
        {
            candidate.Clear();

	        for(int i = 0;i < (int)DirectionType.maxDir;i++) {

		        var nowPosSquare = squareLis[nowPos.y][nowPos.x];

		        if (nowPosSquare == null) {
					button[i].gameObject.SetActive(false);
					continue;
		        }

                if (i >= squareLis[nowPos.y][nowPos.x].PositionLis.Count) continue;

				// 次に行ける可能性のあるマス
				int index_x = squareLis[nowPos.y][nowPos.x].PositionLis[i].x;
		        int index_y = squareLis[nowPos.y][nowPos.x].PositionLis[i].y;

				var square = squareLis[index_y][index_x];

		        if(square == null) {
			        button[i].gameObject.SetActive(false);
			        continue;
		        }

		        if((index_x != 0 && index_y != 0) && square.Square != 0 &&
					(index_x != oneBeforePos.x || index_y != oneBeforePos.y)) {
			        candidate.Add(squareLis[nowPos.y][nowPos.x].PositionLis[i]);

			        button[i].gameObject.SetActive(true);
		        }
		        else button[i].gameObject.SetActive(false);
	        }
		}

        /// <summary>
        /// 歩ける数
        /// </summary>
        /// <param name="count"></param>
        public void GetMoveCount(int count)
        {
            PlayerState = PlayerActionState.move;
            moveCount = count;

            moveCountText.text = moveCount.ToString();
        }

        void Move()
        {
            oneBeforePos = nowPos;
            nowPos = nextPos;

	        if (moveCount > 0) {
		        moveCount--;
            }

	        moveCountText.text = moveCount.ToString();

	        transform.position = mapPosLis[nowPos.y][nowPos.x].transform.localPosition;

            CheckEnd();

            if (moveCount <= 0)
            {
                PlayerState = PlayerActionState.squareAction;
				ExecuteAction();
                mapChanged.TurnDown();
                return;
            }
        }

        /// <summary>
        /// ボタンを押したら移動
        /// </summary>
        public void OnNorthButton()
        {
            if (PlayerState != PlayerActionState.move) return;

            nextPos.x = squareLis[nowPos.y][nowPos.x].PositionLis[(int)DirectionType.north].x;
            nextPos.y = squareLis[nowPos.y][nowPos.x].PositionLis[(int)DirectionType.north].y;

            Move();
            NextSquare();
        }

        public void OnSorthButton()
        {
            if (PlayerState != PlayerActionState.move) return;

            nextPos.x = squareLis[nowPos.y][nowPos.x].PositionLis[(int)DirectionType.south].x;
            nextPos.y = squareLis[nowPos.y][nowPos.x].PositionLis[(int)DirectionType.south].y;

            Move();
            NextSquare();
        }

        public void OnWestButton()
        {
            if (PlayerState != PlayerActionState.move) return;

            nextPos.x = squareLis[nowPos.y][nowPos.x].PositionLis[(int)DirectionType.west].x;
            nextPos.y = squareLis[nowPos.y][nowPos.x].PositionLis[(int)DirectionType.west].y;

            Move();
            NextSquare();
        }

        public void OnEastButton()
        {
            if (PlayerState != PlayerActionState.move) return;

            nextPos.x = squareLis[nowPos.y][nowPos.x].PositionLis[(int)DirectionType.east].x;
            nextPos.y = squareLis[nowPos.y][nowPos.x].PositionLis[(int)DirectionType.east].y;

            Move();
            NextSquare();
        }
    }
}
