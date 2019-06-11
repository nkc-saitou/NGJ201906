using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    [Header("マスオブジェクトのトランスフォームを順番に入れていく")]
    public GameObject mass;
    [Header("マスを作る数")]
    public float createMass;

    List<Transform> massTransformLis = new List<Transform>();

    float degree = 0.0f;
    float nSpeed = 50.0f; // オブジェクトの移動するスピード
    float nDegreeToRadian = Mathf.PI / 180.0f; // nDegreeの値をラジアンに変換する
    float nRadian; // nDegreeの値をラジアンに変換した値
    float nCenterX = 0.0f; // 楕円運動の水平中心座標
    float nCenterY = 0.0f; // 楕円運動の垂直中心座標
    float nRadiusX = 7.0f; // 楕円運動の水平方向の半径
    float nRadiusY = 5.0f; // 楕円運動の垂直方向の半径

    void Start()
    {
        for(int i = 0; i < createMass; i++)
        {
            GameObject tmpObj = Instantiate(mass, mass.transform.position, mass.transform.rotation);
            massTransformLis.Add(tmpObj.transform);
        }

        float massDegree = 360 / createMass;
        Debug.Log(massDegree);

        for (int i = 0; i < createMass; i++)
        {
            degree = ((massDegree * i) % 360 + 360) % 360; // nDegreeの値を0から360までの間の数値に変換する
            nRadian = degree * nDegreeToRadian; // nDegreeの値をラジアンに変換した値をnRadianに入れる

            massTransformLis[i].position = new Vector3(nCenterX + Mathf.Cos(nRadian) * nRadiusX, nCenterY + Mathf.Sin(nRadian) * nRadiusY, 0);
        }
    }
}
