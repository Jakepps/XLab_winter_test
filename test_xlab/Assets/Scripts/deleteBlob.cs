using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TestXlab
{
    public class deleteBlob : MonoBehaviour
    {
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                Destroy(gameObject);
            }
        }
    }
}