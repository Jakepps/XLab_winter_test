using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressX : MonoBehaviour
{
    public GameObject stonePrefab;
    public Vector3 spawnPosition;
    public float spawnForce = 30f;
    public float spawnTorque = 20f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject stone = Instantiate(stonePrefab, spawnPosition, Quaternion.identity);
            Rigidbody rb = stone.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * spawnForce, ForceMode.Impulse);
            rb.AddTorque(new Vector3(0, 0, spawnTorque), ForceMode.Impulse);
        }
    }
}
