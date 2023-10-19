using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestXlab
{

    public class Spawner : MonoBehaviour
    {
        public GameObject[] prefabs;
        public static GameObject currentBall;

        public GameObject Spawn()
        {
            var prefab = GetRandomPrefab();

            if (prefab == null)
            {
                Debug.LogError("Spawner - prefab == null");
                return null;
            }

            currentBall = Instantiate(prefab, transform.position, Quaternion.identity);
            return currentBall;
        }

        public GameObject SetCurrentBall()
        {
            return currentBall;
        }

        private GameObject GetRandomPrefab()
        {
            if (prefabs.Length == 0)
            {
                Debug.LogError("Spawner - prefabs is empty!");
                return null;
            }

            int index = Random.Range(0, prefabs.Length);
            return prefabs[index];
        }
    }
}