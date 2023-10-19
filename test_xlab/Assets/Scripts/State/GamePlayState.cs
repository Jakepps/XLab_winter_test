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
        public GameState gameWinState;
        public TMP_Text scoreText;
        public FailAnim failAnim;

        private int playerScore = 0;

        //public Transform destination;
        //public GameObject stickCopy;

        //private void Start()
        //{
        //    stickCopy = GameObject.Find("Stick");
        //}

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
            Exit();
            //stickCopy = Instantiate(stickCopy);
            //stickCopy.transform.SetParent(destination);
            //stickCopy.transform.position = destination.position;

            failAnim.GameOverAnim();
            
            gameOverState.Enter();
        }

        public void OnGameWin()
        {
            Exit();
            gameWinState.Enter();
        }

        //public void destroyCopy()
        //{
        //    Destroy(stickCopy);
        //}

        protected override void OnDisable()
        {
            base.OnDisable();

            GameEvents.onCollisionStones -= OnGameOver;

            levelController.enabled = false;
            playerController.enabled = false;
        }

    }
}
