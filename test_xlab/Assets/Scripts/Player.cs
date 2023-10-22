using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Player : MonoBehaviour
    {
        public float range = 50f;
        public float speed = 500f;
        public float power = 30f;

        private bool m_isDown = false;
        [SerializeField] private Rigidbody m_rb;
        private Quaternion m_offset;

        private void Awake()
        {
            m_offset = m_rb.rotation;
        }


        private void FixedUpdate()
        {
            Quaternion rot = m_rb.rotation;
            Quaternion toRot = m_offset * Quaternion.Euler(0, m_isDown ? -range : range, 0);
            m_rb.MoveRotation(Quaternion.RotateTowards(rot, toRot, speed * Time.fixedDeltaTime));
        }

        public void SetDown(bool value)
        {
            m_isDown = value;
        }

        public void OnCollisonStick(Collider collider)
        {
            if (collider.TryGetComponent(out Stone stone) && !stone.isAfect)
            {
                stone.isAfect = true;
                GameEvents.StickHit();
            }
        }
    }
}