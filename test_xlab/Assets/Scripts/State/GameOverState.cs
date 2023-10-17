using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class GameOverState : GameState
    {
        public GameState mainMenuState;
        public LevelController levelController;
        public FailAnim failAnim;
        //private GameplayState playState;

        public void Restart()
        {
            //playState.destroyCopy();
            levelController.ClearStones();
            failAnim.RestartAnim();

            Exit();
            mainMenuState.Enter();
        }
    }
}
