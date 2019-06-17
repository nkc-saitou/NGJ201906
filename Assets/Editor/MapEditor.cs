using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

namespace Saitou.Editor
{

    public class MapEditor : EditorWindow
    {
        //-----------------------------------------
        // private
        //-----------------------------------------

        // イメージが入っている画像ディレクトリ
        Object inputDirectory;

        // データ出力先のディレクトリ
        Object outputDirectory;

        Object LoadSquareData;

        // 出力する際のファイル名
        string outputFileName = "NewOutputFile";

        MapCreater mapCreater;

        public string SelectedImagePath { get; private set; }

        List<string> tmpPathLis = new List<string>();
        public List<string> ImagePathList
        {
            get { return tmpPathLis; }
            private set { tmpPathLis = value; }
        }

        public int MapSize { get; private set; }

        public float GridSize { get; private set; }

        public SquareDataSerialize SquareData { get; private set; }

        /// <summary>
        /// WindowﾀﾌﾞにMapCreaterを追加
        /// </summary>
        [MenuItem("Window/MapCreater")]
        static void ShowTestMainWindow()
        {
            GetWindow(typeof(MapEditor));
        }

        void OnGUI()
        {
            EditorGUILayout.LabelField("スゴロク用マップツール");
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("新規で作りたい場合は再読み込みデータには何も入れないでね");


            if (mapCreater == null)
                mapCreater = new MapCreater();

            // エディタ基本情報
            GUILayout.BeginVertical();
            {
                // データの再読み込み
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("再読み込みデータ ", GUILayout.Width(130));
                    LoadSquareData = EditorGUILayout.ObjectField(LoadSquareData, typeof(Object), true);

                    if (LoadSquareData != null)
                    {
                        // パス取得、データ読み込み
                        string squareDataPath = AssetDatabase.GetAssetPath(LoadSquareData);
                        SquareData = AssetDatabase.LoadAssetAtPath(squareDataPath, typeof(ScriptableObject)) as SquareDataSerialize;
                    }

                    GUILayout.EndHorizontal();
                    EditorGUILayout.Space();
                }

                // エディタで使う画像あれこれ
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("画像読み込みフォルダ ", GUILayout.Width(130));
                    // 任意のオブジェクトの Type を表示するフィールドを作成
                    //オブジェクトをドラッグアンドドロップするか Object Picker を使用してオブジェクトを選択するかのいずれかでオブジェクトを割り当てる
                    inputDirectory = EditorGUILayout.ObjectField(inputDirectory, typeof(Object), true);
                    GUILayout.EndHorizontal();
                    EditorGUILayout.Space();
                }

                // マップ全体の大きさ
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("マップの大きさ ", GUILayout.Width(130));
                    if (LoadSquareData == null) MapSize = EditorGUILayout.IntField(MapSize);
                    else MapSize = EditorGUILayout.IntField(SquareData.Map.Count);
                    GUILayout.EndHorizontal();
                    EditorGUILayout.Space();
                }

                // グリッドの大きさ
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("マス目の大きさ ", GUILayout.Width(130));
                    GridSize = EditorGUILayout.FloatField(GridSize);
                    GUILayout.EndHorizontal();
                    EditorGUILayout.Space();
                }

                // 出力したデータを保存するフォルダ
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("保存するフォルダ ", GUILayout.Width(130));
                    outputDirectory = EditorGUILayout.ObjectField(outputDirectory, typeof(Object), true);
                    GUILayout.EndHorizontal();
                    EditorGUILayout.Space();
                }

                // データの名前
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("ファイルネーム ", GUILayout.Width(130));
                    outputFileName = EditorGUILayout.TextField(outputFileName);
                    GUILayout.EndHorizontal();
                    EditorGUILayout.Space();
                }



                GUILayout.EndHorizontal();
            }



            DrawImages();
            DisplaySelectedImage();
            OpenMapWindowButton();
        }

        /// <summary>
        /// 画像配置
        /// </summary>
        void DrawImages()
        {
            if (inputDirectory == null) return;

            float x = 0.0f;
            float y = 0.0f;

            const float w = 50.0f;
            const float h = 50.0f;
            const float maxW = 200.0f;

            // アセットが保存されているプロジェクトフォルダーのパス名
            string path = AssetDatabase.GetAssetPath(inputDirectory);
            // pathで指定されたフォルダ以下のファイルパスを全て取得する
            string[] fileNames = Directory.GetFiles(path, "*.png");

            // ファイルデータを個別で保存しておく
            ImagePathList.AddRange(fileNames);

            EditorGUILayout.BeginVertical();
            {
                for(int i = 0; i < fileNames.Length; i++)
                {
                    // 横がmaxWを超えていたら改行する
                    if (x > maxW)
                    {
                        x = 0.0f;
                        y += h;
                        EditorGUILayout.EndHorizontal();
                    }
                    // ０の場合は横からボタンを置いていく
                    if (x == 0.0f)
                    {
                        EditorGUILayout.BeginHorizontal();
                    }

                    // テクスチャを取得
                    Texture2D tex = (Texture2D)AssetDatabase.LoadAssetAtPath(fileNames[i], typeof(Texture2D));

                    // ボタンを配置
                    if (GUILayout.Button(tex, GUILayout.MaxWidth(w), GUILayout.MaxHeight(h),
                        GUILayout.ExpandWidth(false), GUILayout.ExpandHeight(false)))
                    {
                        SelectedImagePath = fileNames[i];
                    }

                    // 位置を調整
                    x += w;
                }
                EditorGUILayout.EndVertical();
            }
        }

        /// <summary>
        /// 選択した画像を確認する
        /// </summary>
        void DisplaySelectedImage()
        {
            if(SelectedImagePath != null)
            {
                Texture2D tex = (Texture2D)AssetDatabase.LoadAssetAtPath(SelectedImagePath,typeof(Texture2D));

                EditorGUILayout.BeginVertical();
                {
                    GUILayout.Label("選択画像のパス :" + SelectedImagePath);
                    GUILayout.Box(tex);
                    EditorGUILayout.EndVertical();
                }
            }
        }

        /// <summary>
        /// マップエディタを開くボタンを作る
        /// </summary>
        void OpenMapWindowButton()
        {
            EditorGUILayout.BeginVertical();
            GUILayout.FlexibleSpace();

            if (GUILayout.Button("マップエディタ画面を開く"))
            {
                mapCreater = MapCreater.WillApper(this);
            }
            else
            {
                mapCreater.Focus();
            }

            EditorGUILayout.EndVertical();
        }

        /// <summary>
        /// 出力したファイルのパスの指定と取得
        /// </summary>
        /// <returns></returns>
        public string OutputFilePath()
        {
            string resultPath = "";

            // nullでなければ指定された場所に保存
            if (outputDirectory != null) resultPath = AssetDatabase.GetAssetPath(outputDirectory);
            // nullだったばあいはAssetフォルダ直下に保存される
            else resultPath = Application.dataPath;

            return resultPath + "/" + outputFileName;
        }
    }
}
