using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class FailAnim : GameState
    {
        public Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void GameOverAnim()
        {
            animator.SetTrigger("Fail");
        }

        public void RestartAnim() 
        {
            animator.SetTrigger("Restart");
        }
    }
}