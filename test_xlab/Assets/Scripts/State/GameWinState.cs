using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class GameWinState : GameState
    {
        public GameState mainMenuState;
        public LevelController levelController;
        public WinAnim winAnim;

        public void Restart()
        {
            levelController.ClearStones();
            winAnim.RestartAnim();

            Exit();
            mainMenuState.Enter();
        }
    }
}