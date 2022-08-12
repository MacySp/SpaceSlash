using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundOutOfBounds : MonoBehaviour
{
    [SerializeField] private float lowerBound = -50f;
    [SerializeField] private float spawnZPosition = 42f;


    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < lowerBound)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,spawnZPosition);
        }
    }
}
