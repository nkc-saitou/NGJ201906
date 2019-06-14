using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager> {

    void Awake()
    {
        //インスタンスがない場合
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// スコア
    /// </summary>
    public int Score { get; private set; }

    /// <summary>
    /// スコアを追加
    /// </summary>
    public void AddScore(int addScore)
    {
        Score += addScore;
    }

    /// <summary>
    /// スコアを消す
    /// </summary>
    public void ResetScore()
    {
        Score = 0;
    }

}
