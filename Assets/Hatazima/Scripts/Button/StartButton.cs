using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

	void Start ()
    {
        
	}

    public void StartButtonDown()
    {
        //SceneManager.LoadScene("MainScene");
        FadeManager.Instance.LoadScene("MainScene");
    }

    void Update ()
    {
		
	}
}
