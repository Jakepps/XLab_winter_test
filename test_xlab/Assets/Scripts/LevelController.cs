using System.Collections;
using System.Collections.Generic;
using TestXlab;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public Spawner spawner;
        public bool isGameOver = false;
        public float delay = 0.5f;

        public float delayMax = 2f;
        public float delayMin = 0.5f;
        public float delayStep = 0.1f;

        private float m_delay = 0f;


        private void Start()
        {
            StartCoroutine(SpawnStoneProc());

            RefreshDelay();
        }

        private void OnEnable()
        {
            Stone.oncCollisionStone += GameOver;
        }

        private void OnDisable()
        {
            Stone.oncCollisionStone -= GameOver;
        }
         
        public void GameOver()
        {
            Debug.Log("!!! GAME OVER !!!");
            enabled = true;
        }

        private IEnumerator SpawnStoneProc()
        {
            do
            {
                yield return new WaitForSeconds(delay);

                spawner.Spawn();
            }
            while (!isGameOver) ;
        }

        public void RefreshDelay()
        {
            m_delay = Random.Range(delayMin, delayMax);
            delayMax = Mathf.Max(delayMin, delayMax - delayStep);
        }
    }
}