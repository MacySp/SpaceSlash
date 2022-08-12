using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoveDown : MonoBehaviour
{
    [SerializeField] private float Speed = 10f;
    private Vector3 StartPos;
    private float RepeatWidth;

    void Start()
    {
        StartPos = transform.position;
        RepeatWidth = GetComponent<BoxCollider>().size.y / 2;
    }


    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * Speed);

        if(transform.position.z < StartPos.y - RepeatWidth)
        {
            transform.position = StartPos;
            //Debug.Log("Background Reset");
        }

    }
}
