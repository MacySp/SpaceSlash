using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireIng : MonoBehaviour
{
    [SerializeField] private GameObject EnemyProjectile;
    private float ShootDelay = 0.75f;
    [SerializeField] private float ShootRate = 1f;

    void Start()
    {
        InvokeRepeating(nameof(Fire),ShootDelay, ShootRate);
    }


    void Fire()
    {
        Instantiate(EnemyProjectile, transform.position, EnemyProjectile.transform.rotation);
    }
}
