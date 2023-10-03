using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain : MonoBehaviour
{
    public GameObject rainPrefab;  
    public Transform[] points;  
    public float speed = 12;  
    private int currentPoint = 0;
    private float timeRain = 5;
    private bool buttonZ = false;

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Z))  buttonZ = true;
        if (buttonZ)
        {
            Vector3 targetPosition = points[currentPoint].position + new Vector3(0,5,0);
            if (transform.position == targetPosition)
            {
                if (timeRain > 0)
                {
                    timeRain -= Time.deltaTime;
                    Instantiate(rainPrefab, transform.position + new Vector3(Random.Range(-1.5f,1.5f),Random.Range(-0.2f,0.2f),Random.Range(-1.5f,1.5f)), Quaternion.identity); 
                }
                else 
                {   
                    timeRain = 5;
                    currentPoint ++;
                    if (currentPoint >= points.Length)
                    {
                        currentPoint = 0;
                    }
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
    }
}