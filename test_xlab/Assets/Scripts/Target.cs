using UnityEngine;
using UnityEngine.Events;

namespace Golf
{
    public class Target : MonoBehaviour
    {
        public UnityEvent onHitBall;

        private bool isWinner = false;

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                isWinner = true;

                onHitBall?.Invoke();
            }
        }

        public bool getWin()
        {
            return isWinner;
        }
    }
}
