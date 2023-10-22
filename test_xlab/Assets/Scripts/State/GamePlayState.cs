using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TestXlab;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Golf
{
    public class GameplayState : GameState
    {
        public LevelController levelController;
        public PlayerController playerController;
        public GameState gameOverState;
        public GameState gameWinState;

        public FailAnim failAnim;
        public WinAnim winAnim;

        protected override void OnEnable()
        {
            base.OnEnable();

            levelController.enabled = true;
            playerController.enabled = true;

            GameEvents.onCollisionStones += OnGameOver;
            GameEvents.onStickHit += OnStickHit;

            foreach (var target in FindObjectsOfType<Target>())
            {
                target.onHitBall.AddListener(OnGameWin);
            }

            OnStickHit();
        }

        private void OnStickHit()
        {

        }

        private void OnGameOver()
        {
            Exit();

            failAnim.GameOverAnim();

            gameOverState.Enter();
        }

        public void OnGameWin()
        {
            Exit();

            winAnim.VictoryAnim();

            gameWinState.Enter();
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            GameEvents.onCollisionStones -= OnGameOver;

            if (levelController)
                levelController.enabled = false;

            if (playerController)
                playerController.enabled = false;
        }

    }
}
