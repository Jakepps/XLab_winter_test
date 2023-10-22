using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{

    public class WinAnim : GameState
    {
        public Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void GameWinAnim()
        {
            animator.SetTrigger("Win");
        }

        public void RestartAnim()
        {
            animator.SetTrigger("Restart");
        }
    }
}