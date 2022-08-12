using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRotation : MonoBehaviour
{
    [SerializeField] private float RotationSpeed = 30.0f;


    void Update()
    {
        //Rotation of the background
        transform.Rotate(Vector3.back * Time.deltaTime * RotationSpeed);
    }
}
