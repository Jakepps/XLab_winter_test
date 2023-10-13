using JetBrains.Annotations;
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
                Debug.Log("player is null!!");
            }
        }

        private void Update()
        {
            if (player != null)
            {
                player.SetDown(Input.GetMouseButton(0));
            }
        }
    }
}