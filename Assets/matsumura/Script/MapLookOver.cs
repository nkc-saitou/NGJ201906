using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace matsumura.LookOver
{

    public class MapLookOver : MonoBehaviour
    {
        //
        GameObject player;
        //
        static public GameObject camera;

        static public float playerX = 0;
        static public float playerY = 0;

        bool moveUp = false;
        bool moveDown = false;
        bool moveRight = false;
        bool moveLeft = false;

        //y:76
        //y:-2
        //x:56
        //x:26

        // Use this for initialization
        void Start()
        {
            //
            player = GameObject.Find("Player").gameObject;
            //
            camera = GameObject.Find("Camera").gameObject;
        }

        // Update is called once per frame
        void Update()
        {
            playerX = player.transform.position.x;
            playerY = player.transform.position.y;

            if(moveUp)
            {
                if(camera.transform.position.y < -2)
                {
                    camera.transform.Translate(0, 0.15f, 0);
                }
            }
            else if(moveDown)
            {
                if (camera.transform.position.y > -76)
                {
                    camera.transform.Translate(0, -0.15f, 0);
                }
            }
            else if(moveRight)
            {
                if (camera.transform.position.x < 56)
                {
                    camera.transform.Translate(0.15f, 0, 0);
                }
            }
            else if(moveLeft)
            {
                if (camera.transform.position.x > 26)
                {
                    camera.transform.Translate(-0.15f, 0, 0);
                }
            }
        }

        public void UpStrat()
        {
            moveUp = true;
        }

        public void UpEnd()
        {
            moveUp = false;
        }

        public void DownStrat()
        {
            moveDown = true;
        }

        public void DownEnd()
        {
            moveDown = false;
        }

        public void RightStrat()
        {
            moveRight = true;
        }

        public void RightEnd()
        {
            moveRight = false;
        }

        public void LeftStrat()
        {
            moveLeft = true;
        }

        public void LeftEnd()
        {
            moveRight = false;
        }


    }
}
