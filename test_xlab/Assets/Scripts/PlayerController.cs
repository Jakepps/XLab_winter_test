using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestXlab
{

    public class PlayerController : MonoBehaviour
    {
		public Spawner spawner;
		public CloudController cloudController;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.X))
			{
				Debug.Log("X key down");
				spawner.Spawn();
			}

			if (Input.GetKeyDown(KeyCode.Z))
			{
				Debug.Log("Z key down");
				cloudController.Action();
			}

			if (Input.GetKeyDown(KeyCode.Space))
			{
				Debug.Log("Space key down");
			}
		}
	}
}