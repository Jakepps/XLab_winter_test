using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class SwingAnim : GameState
    {
        public Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void SwingBeg()
        {
            animator.SetTrigger("ButtOn");
        }

        public void SwingEnd()
        {
            animator.SetTrigger("ButtOff");
        }
    }
}