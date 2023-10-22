using Cinemachine;
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

        public int score = 0;
        public int hightScore = 0;

        private List<GameObject> m_stones = new List<GameObject>(16);

        private bool isBallSpawn = false;

        [SerializeField] private CinemachineFreeLook freeLookCamera;
        private GameObject currentBall;

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
            isBallSpawn = false;
        }

        private void OnEnable()
        {
            GameEvents.onStickHit += OnStickHit;
            score = 0;
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

            currentBall = spawner.SetCurrentBall();

            if (currentBall != null && freeLookCamera != null)
            {
                freeLookCamera.Follow = currentBall.transform;
                freeLookCamera.LookAt = currentBall.transform;
            }
        }

        private void Update()
        {
            if (isBallSpawn)
            {
                var stone = spawner.Spawn();
                m_stones.Add(stone);

                isBallSpawn = false;
            }
        }

        public void ActiveSpawn()
        {
            isBallSpawn = true;
        }

    }
}