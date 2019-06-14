using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Saitou.Editor
{
    public class MapCreater : EditorWindow
    {
        // マップウィンドウのサイズ
        const float WINDOW_W = 750.0f;
        const float WINDOW_H = 1000.0f;

        // マップのグリッド数
        int mapSize = 0;
        // グリッドサイズ。MapEditor値をもらう
        float gridSize = 0.0f;
        // マップデータ
        string[,] map;
        // グリッドの四角
        Rect[,] gridRect;
        // MapEditorの参照を持つ
        MapEditor editor;

        List<List<int>> dataLis = new List<List<int>>();


        /// <summary>
        /// マップエディタを開く(実際にチップを置いていくウィンドウ)
        /// </summary>
        /// <param name="_editor"></param>
        /// <returns></returns>
        public static MapCreater WillApper(MapEditor _editor)
        {
            MapCreater creater = (MapCreater)GetWindow(typeof(MapCreater));

            creater.Show();
            creater.minSize = new Vector2(WINDOW_W, WINDOW_H);
            creater.SetEditor(_editor);
            creater.Init();

            return creater;


        }
        /// <summary>
        /// 初期化
        /// </summary>
        public void Init()
        {
            mapSize = editor.MapSize;
            gridSize = editor.GridSize;

            // マップデータを初期化
            map = new string[mapSize, mapSize];
            for (int y = 0; y < mapSize; y++)
            {
                for (int x = 0; x < mapSize; x++)
                {
                    map[y, x] = "";
                }
            }

            // グリッドデータを生成
            gridRect = CreateGrid(mapSize);
        }


        void OnGUI()
        {

            for (int grid_y = 0; grid_y < mapSize; grid_y++)
            {
                for (int grid_x = 0; grid_x < mapSize; grid_x++)
                {
                    DrawGridLine(gridRect[grid_y, grid_x]);
                }
            }

            // クリックしされた位置を探し、その場所に画像データを追加
            Event e = Event.current;
            if(e.type == EventType.MouseDrag || e.type == EventType.MouseDown)
            {
                Vector2 pos = Event.current.mousePosition;
                int mouse_x;
                for(mouse_x = 0; mouse_x < mapSize; mouse_x++)
                {
                    Rect r = gridRect[0, mouse_x];

                    // 外にはみ出したら処理をしない
                    if (r.x <= pos.x && pos.x <= r.x + r.width) break;
                }

                for(int mouse_y = 0; mouse_y < mapSize; mouse_y++)
                {
                    if (mouse_x >= mapSize || mouse_y >= mapSize) return;

                    if(gridRect[mouse_y,mouse_x].Contains(pos))
                    {
                        // 消しゴムの時はデータを消す
                        if(editor.SelectedImagePath.IndexOf("000") > -1)
                        {
                            map[mouse_y, mouse_x] = editor.DeleteImagePath;
                        }
                        else
                        {
                            map[mouse_y, mouse_x] = editor.SelectedImagePath;
                        }
                        // 再描画
                        Repaint();
                        break;
                    }
                }
            }

            // 選択した画像を描画する
            for(int mouse_y = 0; mouse_y < mapSize; mouse_y++)
            {
                for(int mouse_x = 0; mouse_x < mapSize; mouse_x++)
                {
                    if(map[mouse_y,mouse_x] != null && map[mouse_y,mouse_x].Length > 0)
                    {
                        Texture2D tex = (Texture2D)AssetDatabase.LoadAssetAtPath(map[mouse_y, mouse_x], typeof(Texture2D));
                        GUI.DrawTexture(gridRect[mouse_y, mouse_x], tex);
                    }
                }
            }

            // 出力ボタン
            Rect outPutRect = new Rect(0, WINDOW_H - 50, 300, 50);
            GUILayout.BeginArea(outPutRect);
            {
                if (GUILayout.Button("出力", GUILayout.MinWidth(300), GUILayout.MinHeight(50)))
                {
                    OutputFile();
                }
                GUILayout.EndArea();
            }

            Rect allDeleteRect = new Rect(400, WINDOW_H - 50, 300, 50);
            GUILayout.BeginArea(allDeleteRect);
            {
                if (GUILayout.Button("すべて削除", GUILayout.MinWidth(700), GUILayout.MinHeight(50)))
                {
                    for(int i = 0; i < mapSize; i++)
                    {
                        for(int j = 0; j < mapSize; j++)
                        {
                            map[i, j] = editor.DeleteImagePath;
                        }
                    }
                }
                GUILayout.EndArea();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_editor"></param>
        void SetEditor(MapEditor _editor)
        {
            editor = _editor;
        }

        /// <summary>
        /// グリッドデータの作成
        /// </summary>
        /// <param name="div"></param>
        /// <returns></returns>
        Rect[,] CreateGrid(int div)
        {
            int sizeW = div;
            int sizeH = div;

            float index_x = 0.0f;
            float index_y = 0.0f;
            float index_w = gridSize;
            float index_h = gridSize;

            Rect[,] resultRects = new Rect[sizeH, sizeW];

            for(int y = 0; y < sizeH; y++)
            {
                index_x = 0.0f;
                for(int x = 0; x < sizeW; x++)
                {
                    Rect r = new Rect(new Vector2(index_x, index_y), new Vector2(index_w, index_h));
                    resultRects[y, x] = r;
                    index_x += index_w;
                }
                index_y += index_h;
            }

            return resultRects;
        }

        /// <summary>
        /// グリッド線の描画
        /// </summary>
        /// <param name="r"></param>
        void DrawGridLine(Rect r)
        {
                Handles.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

                // upper line
                Handles.DrawLine(
                    new Vector2(r.position.x, r.position.y),
                    new Vector2(r.position.x + r.size.x, r.position.y));

                // bottom line
                Handles.DrawLine(
                    new Vector2(r.position.x, r.position.y + r.size.y),
                    new Vector2(r.position.x + r.size.x, r.position.y + r.size.y));

                // left line
                Handles.DrawLine(
                    new Vector2(r.position.x, r.position.y),
                    new Vector2(r.position.x, r.position.y + r.size.y));

                // right line
                Handles.DrawLine(
                    new Vector2(r.position.x + r.size.x, r.position.y),
                    new Vector2(r.position.x + r.size.x, r.position.y + r.size.y));
        }

        /// <summary>
        /// ファイル出力
        /// </summary>
        void OutputFile()
        {
            string path = editor.OutputFilePath();

            GetMapStringFormat();

            SquareDataSerialize asset = CreateInstance<SquareDataSerialize>();
            asset.Map = dataLis;

            AssetDatabase.CreateAsset(asset, path + ".asset");
            EditorUtility.DisplayDialog("MapCreater", "output file success\n" + path, "ok");

            // scriptableObjectの値を保存する
            EditorUtility.SetDirty(asset);
            AssetDatabase.SaveAssets();
        }

        /// <summary>
        /// データ１つ１つを出力するフォーマット
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int OutputDataFormat(string data)
        {
            if(data != null && data.Length > 0)
            {
                string[] temps = data.Split('/');
                string fileName = temps[temps.Length - 1];

                return int.Parse((fileName.Split('.')[0][16]).ToString());
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// どういう形式でデータを出力するか
        /// </summary>
        /// <returns></returns>
        void GetMapStringFormat()
        {
            int result = 0;

            if (dataLis.Count != 0) dataLis.Clear();

            for(int y = 0; y < mapSize; y++)
            {
                List<int> tmpLis = new List<int>();

                for (int x = 0; x < mapSize; x++)
                {
                    // データの数などを取得
                    result = OutputDataFormat(map[y, x]);

                    tmpLis.Add(result);
                }

                // リストに追加
                dataLis.Add(tmpLis);

            }
        }

    }
}
