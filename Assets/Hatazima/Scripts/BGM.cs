using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
	void Start ()
    { 
        AudioManager.Instance.PlayBGM("Title");
    }
	
	void Update ()
    {

	}

    public void StartButtonDown()
    {
        AudioManager.Instance.PlayBGM("Main");
    }
}
