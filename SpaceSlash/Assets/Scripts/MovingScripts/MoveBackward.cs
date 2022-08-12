using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackward : MonoBehaviour
{
    [SerializeField] private float Speed = 10.0f;

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * Speed);
    }
}
