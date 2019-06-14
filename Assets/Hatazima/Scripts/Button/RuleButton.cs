using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleButton : MonoBehaviour
{
	void Start ()
    {
		
	}

    public void RuleButtonDown()
    {
        SceneManager.LoadScene("Rule");
    }

    void Update ()
    {
		
	}
}
