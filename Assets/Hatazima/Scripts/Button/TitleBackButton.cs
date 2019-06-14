using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBackButton : MonoBehaviour
{
	void Start ()
    {
		
	}

    public void TitleBackButtonDown()
    {
        SceneManager.LoadScene("Title");
    }

    void Update ()
    {
		
	}
}
