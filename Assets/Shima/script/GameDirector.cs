using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace shima
{
    public class GameDirector : MonoBehaviour
    {
        GameObject text;
        int koukando = 50;//好感度の初期値

        // Use this for initialization
        void Start()
        {
            this.text = GameObject.Find("koukando");//テキストの呼び出し
        }

        // Update is called once per frame
        void Update()
        {
            this.text.GetComponent<Text>().text =
                "好感度" + koukando;//好感度表示
        }
        public void koukandoUp()
        {
            koukando += 10;
        }
        public void koukandoDown()
        {
            koukando -= 10;
        }
    }
}
