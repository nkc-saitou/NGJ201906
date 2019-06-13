using System.Collections;
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
        south,
        west,
        east,
        north,
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

        GameObject createParen;

        public List<List<int>> MapData { get; private set; }
        public List<List<Transform>> MapPosLis { get; private set; }

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

        void Start()
        {
            MapData = new List<List<int>>();
            MapPosLis = new List<List<Transform>>();

            MapData = data.Map;

            createParen = new GameObject("Parent");

            for (int y = 0; y < MapData.Count; y++)
            {
                List<Transform> tempPosLis = new List<Transform>();
                for (int x = 0; x < MapData.Count; x++)
                {
                    if (MapData[y][x] != (int)E_SqureType.none)
                    {
                        GameObject obj = Instantiate(squareType[MapData[y][x] - 1].gameObject, new Vector3(x * space, y * space, 1.0f), Quaternion.identity, createParen.transform);

                        // 四方でつながっているマスを取得する
                        obj.GetComponent<SquareType>().PositionLis = SetConnection(x, y);

                        tempPosLis.Add(obj.transform);

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
                    }
                    else
                    {
                        tempPosLis.Add(null);
                    }
                }
                MapPosLis.Add(tempPosLis);
            }
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

            checkArray[(int)DirectionType.south].x = x;
            checkArray[(int)DirectionType.south].y = (y - 1 >= 0) ? y - 1 : 0;

            checkArray[(int)DirectionType.west].x = (x - 1 >= 0) ? x - 1: 0;
            checkArray[(int)DirectionType.west].y = y;

            checkArray[(int)DirectionType.east].x = x + 1;
            checkArray[(int)DirectionType.east].y = y;

            checkArray[(int)DirectionType.north].x = x;
            checkArray[(int)DirectionType.north].y = y + 1;


            for(int i = 0; i < (int)DirectionType.maxDir; i++)
            {
                if (squareType[MapData[checkArray[i].y][checkArray[i].x] - 1].Squre != E_SqureType.none)
                {
                    Debug.Log(squareType[MapData[checkArray[i].y][checkArray[i].x] - 1].Squre);
                    tempLis.Add(checkArray[i]);
                }
            }

            return tempLis;
        }
    }
}