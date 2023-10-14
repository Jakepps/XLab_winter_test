using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Player player;

        private void Start()
        {
            if (player == null)
            {
                Debug.Log("Player is null!!!");
            }
        }

        private void Update()
        {
            //if (player != null)
            //{
            //	player.SetDown(Input.GetMouseButton(0));
            //}
        }

        public void OnDown()
        {
            player.SetDown(true);
        }

        public void OnUp()
        {
            player.SetDown(false);
        }
    }
}