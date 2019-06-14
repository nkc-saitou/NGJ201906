using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Saitou.Test;
using Saitou.System;
using Saitou.Squares;
using UnityEngine.UI;

namespace Saitou.Player
{
    public enum PlayerActionState
    {
        wait,
        move,
        actionSelect,
    }

    public class PlayerMove : MonoBehaviour
    {
        public MapCreate create;

        [Header("south,west,east,north")]
        public Button[] button;

        List<List<int>> mapData = new List<List<int>>();
        List<List<Transform>> mapPosLis = new List<List<Transform>>();
        List<List<SquareType>> squareLis = new List<List<SquareType>>();

        List<Position> candidate = new List<Position>();

        Position startPos;
        Position goalPos;

        // 現在の位置
        Position nowPos;

        // ひとつ前の位置
        Position oneBeforePos;

        // 次の目的地
        Position nextPos;

        // 移動時間
        float time;
        float startTime;

        // 位置移動の座標
        Vector3 startPosition;
        Vector3 endPosition;

        // 動ける数
        int moveCount = 0;

        PlayerActionState state = PlayerActionState.wait;

        /// <summary>
        /// MapCreateよりも遅く実行する
        /// </summary>
        /// <returns></returns>
        IEnumerator Start()
        {
            // 処理順の調整
            yield return new WaitForSeconds(0.1f);
            InitSetValue();

            startPosition = transform.localPosition;

            NextSquare();
        }

        /// <summary>
        ///  値の初期化
        /// </summary>
        void InitSetValue()
        {
            startPos.x = create.StartPos.x;
            startPos.y = create.StartPos.y;

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

            for(int i = 0; i < (int)DirectionType.maxDir; i++)
            {
                // 次に行ける可能性のあるマス
                int index_x = squareLis[nowPos.y][nowPos.x].PositionLis[i].x;
                int index_y = squareLis[nowPos.y][nowPos.x].PositionLis[i].y;

                if (index_x != 0 && index_y != 0 && squareLis[index_y][index_x].Squre != 0)
                {
                    candidate.Add(squareLis[nowPos.y][nowPos.x].PositionLis[i]);

                    button[i].gameObject.SetActive(true);
                }
                else button[i].gameObject.SetActive(false);
            }
        }

        private void Update()
        {

        }

        /// <summary>
        /// 移動開始
        /// </summary>
        /// <param name="moveSquareCount">移動できるマスの数</param>
        void MoveStart(int moveSquareCount)
        {
            moveCount = moveSquareCount;
        }

        void Move()
        {
            nowPos.x = nextPos.x;
            nowPos.y = nextPos.y;

            transform.position = mapPosLis[nowPos.y][nowPos.x].transform.localPosition;

            Debug.Log("nowPosition :   x" + nowPos.x + "     y " + nowPos.y);
        }

        /// <summary>
        /// ボタンを押したら移動
        /// </summary>
        public void OnNorthButton()
        {
            nextPos.x = squareLis[nowPos.y][nowPos.x].PositionLis[(int)DirectionType.north].x;
            nextPos.y = squareLis[nowPos.y][nowPos.x].PositionLis[(int)DirectionType.north].y;

            Move();
            NextSquare();
        }

        public void OnSorthButton()
        {
            nextPos.x = squareLis[nowPos.y][nowPos.x].PositionLis[(int)DirectionType.south].x;
            nextPos.y = squareLis[nowPos.y][nowPos.x].PositionLis[(int)DirectionType.south].y;

            Move();
            NextSquare();
        }

        public void OnWestButton()
        {
            nextPos.x = squareLis[nowPos.y][nowPos.x].PositionLis[(int)DirectionType.west].x;
            nextPos.y = squareLis[nowPos.y][nowPos.x].PositionLis[(int)DirectionType.west].y;

            Move();
            NextSquare();
        }

        public void OnEastButton()
        {
            nextPos.x = squareLis[nowPos.y][nowPos.x].PositionLis[(int)DirectionType.east].x;
            nextPos.y = squareLis[nowPos.y][nowPos.x].PositionLis[(int)DirectionType.east].y;

            Move();
            NextSquare();
        }
    }
}
