using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Transform[] points;
    public float movementSpeed;
    private int pointIndex;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[pointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointIndex <= points.Length -1)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[pointIndex].transform.position, movementSpeed * Time.deltaTime);

            if(transform.position == points[pointIndex].transform.position) 
            {
                pointIndex += 1;
            }
            if(pointIndex == points.Length)
            {
                pointIndex = 0;
            }
        }
    }
}
