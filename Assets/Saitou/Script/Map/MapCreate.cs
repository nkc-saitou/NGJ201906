﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Saitou.Squares
{
    /// <summary>
    /// 添え字
    /// </summary>
    public struct Position
    {
        public int x;
        public int y;
    }

    public enum DirectionType
    {
        north,
        west,
        east,
        south,
        maxDir,
    }

    public class MapCreate : MonoBehaviour
    {
        [Header("ステージデータ")]
        public SquareDataSerialize data;

        [Header("マス : Start,Goal,Up,Down,Special")]
        public SquareType[] squareType;

        [Header("マスごとのスペース")]
        public int space;

        [Header("LineRendererを引くためのPrefab")]
        public SquareLineRenderer DrawLinePre;

        GameObject createParen;
        GameObject lineParent;

        public List<List<int>> MapData { get; private set; }
        public List<List<Transform>> MapPosLis { get; private set; }
        public List<List<SquareType>> SquareLis { get; private set; }

        Position startPos;
        public Position StartPos
        {
            get { return startPos; }
            private set { startPos = value; }
        }

        Position goalPos;
        public Position GoalPos
        {
            get { return goalPos; }
            private set { goalPos = value; }
        }

        Position maxWest;
        public Position MaxWest
        {
            get { return maxWest; }
            private set { maxWest = value; }
        }

        Position maxEast;
        public Position MaxEast
        {
            get { return maxEast; }
            private set { maxEast = value; }
        }

        void Start()
        {
            MapData = new List<List<int>>();
            MapPosLis = new List<List<Transform>>();
            SquareLis = new List<List<SquareType>>();

            MapData = data.Map;

            createParen = new GameObject("Parent");
            lineParent = new GameObject("LineParent");

            for (int y = 0; y < MapData.Count; y++)
            {
                List<Transform> tempPosLis = new List<Transform>();
                List<SquareType> tempSquareLis = new List<SquareType>();

                for (int x = 0; x < MapData.Count; x++)
                {
                    if (MapData[y][x] != (int)E_SqureType.none)
                    {
                        // スタート、ゴール位置は別で取得しておく
                        if (MapData[y][x] == (int)E_SqureType.start)
                        {
                            startPos.x = x;
                            startPos.y = y;
                        }
                        else if (MapData[y][x] == (int)E_SqureType.goal)
                        {
                            goalPos.x = x;
                            goalPos.y = y;
                        }
                        

                        GameObject obj = Instantiate(squareType[MapData[y][x] - 1].gameObject, new Vector3(x * space, y * -space, 1.0f), Quaternion.identity, createParen.transform);
                        SquareType squareObj = obj.GetComponent<SquareType>();
                        // 四方でつながっているマスを取得する
                        squareObj.PositionLis = SetConnection(x, y);

                        tempPosLis.Add(obj.transform);
                        tempSquareLis.Add(squareObj);
                    }
                    else
                    {
                        tempPosLis.Add(null);
                        tempSquareLis.Add(null);
                    }
                }
                MapPosLis.Add(tempPosLis);
                SquareLis.Add(tempSquareLis);
            }
            DrawLine(SquareLis, MapPosLis);
        }

        /// <summary>
        /// 繋がっているマスを取得する
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        List<Position> SetConnection(int x,int y)
        {
            List<Position> tempLis = new List<Position>();

            Position[] checkArray = new Position[4];

            checkArray[(int)DirectionType.north].x = x;
            checkArray[(int)DirectionType.north].y = y - 1;

            checkArray[(int)DirectionType.west].x = x - 1;
            checkArray[(int)DirectionType.west].y = y;

            checkArray[(int)DirectionType.east].x = x + 1;
            checkArray[(int)DirectionType.east].y = y;

            checkArray[(int)DirectionType.south].x = x;
            checkArray[(int)DirectionType.south].y = y + 1;

            for (int i = 0; i < (int)DirectionType.maxDir; i++)
            {
                int index_y = checkArray[i].y;
                int index_x = checkArray[i].x;
                
                if (index_x < 0 || index_y < 0 || index_x >= MapData.Count || index_y >= MapData.Count) continue;

                int index = (MapData[index_y][index_x] - 1 < 0) ? 0 : MapData[index_y][index_x] - 1;

                if (squareType[index].Square != E_SqureType.none)
                {
                    tempLis.Add(checkArray[i]);
                }
            }

            return tempLis;
        }

        void DrawLine(List<List<SquareType>> type, List<List<Transform>> transformPosLis)
        {
            for (int y = 0; y < MapData.Count; y++)
            {
                for (int x = 0; x < MapData.Count; x++)
                {
                    for (int i = 0; i < (int)DirectionType.maxDir; i++)
                    {
                        if (transformPosLis[y][x] == null || transformPosLis[type[y][x].PositionLis[i].y][type[y][x].PositionLis[i].x] == null) continue;
                        SquareLineRenderer line = Instantiate(DrawLinePre, transform.position, Quaternion.identity, lineParent.transform);
                        line.DrawLine(transformPosLis[y][x], transformPosLis[type[y][x].PositionLis[i].y][type[y][x].PositionLis[i].x]);
                    }
                }
            }
        }
    }
}