using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class GameEvents : MonoBehaviour
    {
        public static event System.Action onCollisionStones;
        public static event System.Action onStickHit;

        public static void CollisionStonesInvoke(Collision collision)
        {
            onCollisionStones?.Invoke();
        }
    }
}