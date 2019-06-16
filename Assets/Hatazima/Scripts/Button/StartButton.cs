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
        AudioManager.Instance.PlaySE("Button");
        FadeManager.Instance.LoadScene("MainScene");
    }

    void Update ()
    {
		
	}
}
