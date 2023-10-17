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
        public FailAnim failAnim;

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
            scoreText.text = $"Score: {levelController.score}";
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
