using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotation : MonoBehaviour
{
    [SerializeField] private readonly float RotationSpeed = 30.0f;

    void Start()
    {
        //Set random rotation when object spawns
        transform.Rotate(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)) ;
    }

    void Update()
    {
        //Object rotation over time
        transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed);
        transform.Rotate(Vector3.left * Time.deltaTime * RotationSpeed);

    }
}
