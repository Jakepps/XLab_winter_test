using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestXlab
{

    public class PlayerController : MonoBehaviour
    {

        public Spawner spawner;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.X)) 
            {
                Debug.Log("X key down");
                spawner.Spawn();
            }
        }
    }
}