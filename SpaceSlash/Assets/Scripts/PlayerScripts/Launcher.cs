using System;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField]
    private Transform[] firePoints;
    [SerializeField]
    private Rigidbody projectilePrefab;
    [SerializeField]
    private float launchForce = 2000f;
    private float fireCooldown = 0.7f;
    private float spawnRate = 0.15f;
    GameManager game;

    //components
    private AudioSource playerAudio;

    //ShootSound
    public AudioClip shootSound;

    //shoot FX
    public ParticleSystem muzzleFX;
    private void Start()
    {
        //Inicialize
        playerAudio = GetComponent<AudioSource>();
        game = FindObjectOfType<GameManager>();
    }

    public void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > fireCooldown && game.IsPlayerAlive)
        {
            //print("Shoot");
            fireCooldown = Time.time + spawnRate;
            foreach (var firePoint in firePoints)
            {
                var projectileInstance = Instantiate(
                    projectilePrefab,
                    firePoint.position,
                    firePoint.rotation);

                projectileInstance.AddForce(firePoint.forward * launchForce);
                playerAudio.PlayOneShot(shootSound , 2f);
                muzzleFX.Play();
            }
        }
    }

    private void LaunchProjectile()
    {

    }
}