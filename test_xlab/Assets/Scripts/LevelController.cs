using System;
using System.Collections;
using System.Collections.Generic;
using TestXlab;
using UnityEngine;

namespace Golf
{

    public class LevelController : MonoBehaviour
    {
        public Spawner spawner;
        private float m_lastSpawnedTime = 0;

        public float delayMax = 2f;
        public float delayMin = 0.3f;
        public float delayStep = 0.05f;

        public int score = 0;
        public int hightScore = 0;

        private float m_delay = 0.5f;

        private List<GameObject> m_stones = new List<GameObject>(16);

        public void ClearStones()
        {
            foreach (var stone in m_stones)
            {
                Destroy(stone);
            }

            m_stones.Clear();
        }

        private void Start()
        {
            m_lastSpawnedTime = Time.time;
            //RefreshDelay();
        }

        private void OnEnable()
        {
            GameEvents.onStickHit += OnStickHit;
            score = 0;
            delayMax = 2f;
        }

        private void OnDisable()
        {
            GameEvents.onStickHit -= OnStickHit;
        }

        private void OnStickHit()
        {
            score++;
            hightScore = Mathf.Max(hightScore, score);

            Debug.Log($"Score: {score} - hightScore: {hightScore}");
        }

        private void Update()
        {
            if (Time.time >= m_lastSpawnedTime + m_delay)
            {
                var stone = spawner.Spawn();
                m_stones.Add(stone);

                m_lastSpawnedTime = Time.time;

                RefreshDelay();
            }
        }

        public void RefreshDelay()
        {
            m_delay = UnityEngine.Random.Range(delayMin, delayMax);
            delayMax = Mathf.Max(delayMin, delayMax - delayStep);
        }

    }
}