using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultButton : MonoBehaviour
{
	void Start ()
    {
		
	}

    public void ResultButtonDown()
    {
        AudioManager.Instance.PlaySE("Button");
        SceneManager.LoadScene("Result");
    }

    void Update ()
    {
		
	}
}
