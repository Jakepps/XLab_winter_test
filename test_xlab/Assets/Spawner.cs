using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestXlab
{
    public class Spawner : MonoBehaviour
    {
        public GameObject prefab;
        public void Spawn()
        {
            Debug.Log("try spawn");

            if (prefab == null)
            {
                Debug.Log("Spawner - refab == null");
                return;
            }

            Instantiate(prefab, transform.position,Quaternion.identity);
        }


    }
}