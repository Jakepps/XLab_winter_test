using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Player player;

        [SerializeField] private SwingAnim SwingAnim;

        private void Start()
        {
            if (player == null)
            {
                Debug.Log("Player is null!!!");
            }
        }

        public void OnDown()
        {
            player.SetDown(true);
            SwingAnim.SwingBeg();
        }

        public void OnUp()
        {
            player.SetDown(false);
            SwingAnim.SwingEnd();
        }
    }
}