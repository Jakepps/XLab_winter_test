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

        private int m_targetIndex = -1;
        private float initialCloudHeight;

        private bool isRain = false;

        public void Action()
        {
            Debug.Log("CloudController - Try action!", this);

            if (m_moved)
            {
                return;
            }

            m_moved = true;
            isRain = false;

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
                 cloud.position = targetPosition;
                 m_moved = false;

                 if (!m_moved)
                 {
                    isRain = true;
                    StartCoroutine(StartRain());
                 } 
            }
            else
            {
                cloud.Translate(offset);
            }
        }
        private IEnumerator StartRain()
        {
            while (isRain)
            {
                Instantiate(rainPrefab, cloud.position + new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-0.2f, 0.2f), Random.Range(-1.5f, 1.5f)), Quaternion.identity);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}