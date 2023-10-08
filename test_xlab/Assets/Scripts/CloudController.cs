using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestXlab
{

	public class CloudController : MonoBehaviour
	{
		public Transform[] targets;
		public Cloud cloud;
        //public GameObject rainPrefab;

        private bool m_moved = false;
        public float moveSpeed = 12f;

        private int m_targetIndex = 0;
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
            //isRain = false;
            cloud.StopFx();

            m_targetIndex++;
            if (m_targetIndex >= targets.Length)
            {
                m_targetIndex = 0;
            }
        }

        private void Start()
        {
            initialCloudHeight = cloud.transform.position.y;
        }

        private void Update()
		{

            if (!m_moved)
            {
                return;
            }

            Transform target = targets[m_targetIndex];
            
            Vector3 targetPosition = new Vector3(target.position.x, initialCloudHeight, target.position.z);

            Vector3 offset = (targetPosition - cloud.transform.position).normalized * moveSpeed * Time.deltaTime;

            if (Vector3.Distance(cloud.transform.position, targetPosition) < offset.magnitude)
            {
                cloud.transform.position = targetPosition;
                m_moved = false;

                cloud.PlayFX();
            }
            else
            {
                cloud.transform.Translate(offset);
            }
        }
        //private IEnumerator StartRain()
        //{
        //    while (isRain)
        //    {
        //        Instantiate(rainPrefab, cloud.transform.position + new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-0.2f, 0.2f), Random.Range(-1.5f, 1.5f)), Quaternion.identity);
        //        yield return new WaitForSeconds(0.01f);
        //    }
        //}
    }
}