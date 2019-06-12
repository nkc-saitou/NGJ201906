using System.Collections.Generic;
using UnityEngine;

namespace Saitou.Squares
{
    /// <summary>
    /// マス目の生成をするクラス
    /// </summary>
    public class SquaresCreator : MonoBehaviour
    {
        //-----------------------------------------
        // private
        //-----------------------------------------

        [Header("マス目オブジェクト"),SerializeField]
        GameObject squaresPre;

        [Header("マス目オブジェクトを管理する親オブジェクト"),SerializeField]
        GameObject squareParent;

        [Header("マスを作る数"),SerializeField]
        float squaresCreateCount;

        [Header("楕円の水平中心座標"), SerializeField]　　float nCenterX = 0.0f;
        [Header("楕円の垂直中心座標"), SerializeField]　　float nCenterY = 0.0f;
        [Header("楕円の水平方向の半径"), SerializeField]　float nRadiusX = 7.0f;
        [Header("楕円の垂直方向の半径"), SerializeField]　float nRadiusY = 5.0f;

        // オブジェクトを管理するリスト
        List<Transform> squaresLis = new List<Transform>();

        //-----------------------------------------
        // 関数
        //-----------------------------------------

        /// <summary>
        /// すごろくのマス目を生成する
        /// </summary>
        [ContextMenu("SquaresCreate")]
        void Create()
        {
            // nDegreeの値をラジアンに変換する
            float nDegreeToRadian = Mathf.PI / 180.0f;

            // オブジェクト同時の均等な間隔を取得
            float squaresSpace = 360 / squaresCreateCount; 

            // マス目の生成
            for (int i = 0; i < squaresCreateCount; i++)
            {
                // nDegreeの値を0から360までの間の数値に変換する
                float degree = ((squaresSpace * i) % 360 + 360) % 360;
                // nDegreeの値をラジアンに変換した値をnRadianに入れる
                float nRadian = degree * nDegreeToRadian; 

                // オブジェクトを生成し、位置を調整する
                GameObject tmpObj = Instantiate(squaresPre, squaresPre.transform.localPosition, squaresPre.transform.localRotation);

                // 楕円型に配置するための計算
                tmpObj.transform.position = new Vector3(nCenterX + Mathf.Cos(nRadian) * nRadiusX, nCenterY + Mathf.Sin(nRadian) * nRadiusY, 0);
                tmpObj.transform.parent = squareParent.transform;

                // オブジェクトをリストに追加
                squaresLis.Add(tmpObj.transform);
            }
        }

        /// <summary>
        /// すごろくのマス目を削除する
        /// </summary>
        [ContextMenu("SquaresDestroy")]
        void Destroy()
        {
            // 生成されていなければ処理をしない
            if (squaresLis.Count < -1) return;

            //実際のオブジェクトを削除
            foreach (Transform squareObj in squaresLis)
            {
                DestroyImmediate(squareObj.gameObject, false);
            }

            squaresLis.RemoveRange(0, squaresLis.Count);
        }
    }
}
