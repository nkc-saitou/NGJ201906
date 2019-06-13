using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace shima
{
    public class cameraController : MonoBehaviour
    {
        GameObject player;

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 playerPos = this.player.transform.position;
            transform.position = new Vector3(
                playerPos.x, playerPos.y, transform.position.z);
        }
    }
}
