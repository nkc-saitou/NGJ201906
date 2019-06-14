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
        SceneManager.LoadScene("Result");
    }

    void Update ()
    {
		
	}
}
