using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Player : MonoBehaviour
    {
        public Transform stick;
        public Transform helper;
        public float range = 30;
        public float speed = 500f;
        public float power = 20f;

        private bool m_isDown = false;

        private Vector3 m_lastPosition;

        private void Update()
        {
            m_lastPosition = helper.position;

            m_isDown = Input.GetMouseButton(0);

            Quaternion rot = stick.localRotation;

            Quaternion toRot = Quaternion.Euler(0, 0,m_isDown ? range : -range);

            stick.localRotation = Quaternion.RotateTowards(rot, toRot, speed * Time.deltaTime);       
        }

        public void OnCollisonStick(Collider collider)
        {
            if (collider.TryGetComponent(out Rigidbody stone))
            {
                var dir = (helper.position - m_lastPosition).normalized;
                stone.AddForce(dir * power, ForceMode.Impulse);

                if   (collider.TryGetComponent(out Stone stones))
                {
                    stones.isAfect = true;
                }
            }
        }
    }
}