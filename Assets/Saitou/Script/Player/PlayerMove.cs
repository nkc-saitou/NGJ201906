using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Saitou.Test;
using Saitou.System;
using Saitou.Squares;

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

        List<List<int>> mapData = new List<List<int>>();
        List<List<Transform>> mapPosLis = new List<List<Transform>>();

        Position startPos;
        Position goalPos;

        // 現在の位置
        Position nowPos;

        // ひとつ前の位置
        Position oneBeforePos;

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
        }

        void Update()
        {
            
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

            transform.position = mapPosLis[nowPos.y][nowPos.x].transform.localPosition;
        }

        void NextSquare()
        {
            
        }

        /// <summary>
        /// 移動開始
        /// </summary>
        /// <param name="moveSquareCount">移動できるマスの数</param>
        void MoveStart(int moveSquareCount)
        {
            state = PlayerActionState.move;
            moveCount = moveSquareCount;
        }

        /// <summary>
        /// ボタンを押したら移動
        /// </summary>
        public void OnClickMove()
        {

        }
    }
}
