using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{

	void Start ()
    {
		
	}

    public void TitleButtonDown()
    {
        SceneManager.LoadScene("MainScene");
    }

    void Update ()
    {
		
	}
}
