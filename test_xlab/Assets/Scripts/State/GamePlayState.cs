using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Golf
{
    public class GameplayState : GameState
    {
        public LevelController levelController;
        public PlayerController playerController;
        public GameState gameOverState;
        public TMP_Text scoreText;

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
            scoreText.text = $"Score: {levelController.score}";
        }

        private void OnGameOver()
        {
            Exit();
            gameOverState.Enter();
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
