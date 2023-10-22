using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class MainMenuState : GameState
    {
        public LevelController levelController;
        public GameState gamePlayState;

        public void PlayGame()
        {
            Exit();
            gamePlayState.Enter();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

        }
    }
}
