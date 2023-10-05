using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestXlab
{

	public class CloudController : MonoBehaviour
	{
		public Transform[] targets;
		public Transform cloud;
        public GameObject rainPrefab;

        private bool m_moved = false;
        public float moveSpeed = 12f;

        private int m_targetIndex = 0;
        private float initialCloudHeight;

        private float timeRain = 5;


        public void Action()
        {
            Debug.Log("CloudController - Try action!", this);

            if (m_moved)
            {
                return;
            }

            m_moved = true;

            m_targetIndex++;
            if (m_targetIndex >= targets.Length)
            {
                m_targetIndex = 0;
            }
        }
        private void Start()
        {
            initialCloudHeight = cloud.position.y;
        }

        private void Update()
		{

            if (!m_moved)
            {
                return;
            }

            Transform target = targets[m_targetIndex];
            
            Vector3 targetPosition = new Vector3(target.position.x, initialCloudHeight, target.position.z);

            Vector3 offset = (targetPosition - cloud.position).normalized * moveSpeed * Time.deltaTime;

            if (Vector3.Distance(cloud.position, targetPosition) < offset.magnitude)
            {
                if (timeRain > 0)
                {
                    cloud.position = targetPosition;

                    timeRain -= Time.deltaTime;
                    Instantiate(rainPrefab, cloud.position + new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-0.2f, 0.2f), Random.Range(-1.5f, 1.5f)), Quaternion.identity);

                    m_moved = false;
                }
                else
                {
                    timeRain = 5;
                }
            }
            else
            {
                cloud.Translate(offset);
            }
            
        }
	}
}