using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingButton : MonoBehaviour
{
	void Start ()
    {
		
	}

    public void RankingButtonDown()
    {
        SceneManager.LoadScene("Ranking");
    }

    void Update ()
    {
		
	}
}
