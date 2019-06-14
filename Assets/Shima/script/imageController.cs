using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace shima
{
    public class imageController : MonoBehaviour
    {
        GameObject textbox;

        // Use this for initialization
        void Start()
        {
            this.textbox = GameObject.Find("textbox");
            this.textbox.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
