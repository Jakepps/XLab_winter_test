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
        public TMP_Text scoreText;

        public FailAnim failAnim;
        public WinAnim winAnim;

        private int playerScore = 0;

        protected override void OnEnable()
        {
            base.OnEnable();

            levelController.enabled = true;
            playerController.enabled = true;

            GameEvents.onCollisionStones += OnGameOver;
            GameEvents.onStickHit += OnStickHit;

            OnStickHit();
        }

        private void OnStickHit()
        {
            playerScore = levelController.score;
            scoreText.text = $"Score: {levelController.score}";

            if (playerScore >= 30)
                OnGameWin();

        }

        private void OnGameOver()
        {
            //Exit();

            //failAnim.GameOverAnim();

            //gameOverState.Enter();
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

            levelController.enabled = false;
            playerController.enabled = false;
        }

    }
}
