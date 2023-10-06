using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestXlab
{

    public class Spawner : MonoBehaviour
    {
        public GameObject[] prefabs;

        public void Spawn()
        {
            Debug.Log("Try spawn!");

            var prefab = GetRandomPrefab();

			if (prefab == null)
            {
                Debug.LogError("Spawner - prefab == null");
                return;
            }

            Instantiate(prefab, transform.position, Quaternion.identity);
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