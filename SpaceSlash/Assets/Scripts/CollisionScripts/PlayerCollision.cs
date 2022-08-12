using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private AudioClip[] HitSounds;
    [SerializeField] private AudioClip PickupSound;
    [SerializeField] private AudioClip PointsPickupSound;
    [SerializeField] private GameObject HitFX;
    [SerializeField] private GameObject FuelFX;
    [SerializeField] private GameObject PointsFX;
    [SerializeField] readonly private float AsteroidDamage = 30f;
    [SerializeField] readonly private float EnemyDamage = 15f;
    [SerializeField] readonly private float EnemyHitDamage = 20f;
    [SerializeField] readonly private float FuelBoost = 30f;
    private AudioSource PlayAudio;
    GameManager Player;
    ScoreManager ScoreManager;



    void Awake()
    {
        //Initalize components
        PlayAudio = GetComponent<AudioSource>();
        Player = FindObjectOfType<GameManager>();
        ScoreManager = FindObjectOfType<ScoreManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Asteroid") && Player.IsPlayerAlive)
        {
            //Debug.Log("You hit asteroid");
            Object.Destroy(other.gameObject);
            Player.FuelLevel = Player.FuelLevel - AsteroidDamage;
        }
        else if (other.gameObject.CompareTag("Enemy") && Player.IsPlayerAlive)
        {
            //Debug.Log("You Hit Enemy");
            Object.Destroy(other.gameObject);
            Player.FuelLevel = Player.FuelLevel - EnemyDamage;
        }
        else if (other.gameObject.CompareTag("Enemy2") && Player.IsPlayerAlive)
        {
            //Debug.Log("You Hit Enemy");
            Object.Destroy(other.gameObject);
            Player.FuelLevel = Player.FuelLevel - EnemyDamage;
        }
        else if (other.gameObject.CompareTag("EnemyProjectile") && Player.IsPlayerAlive)
        {
            //Debug.Log("You hit enemy projectile");
           PlayHitAudio();
            Instantiate(HitFX, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z), Quaternion.identity);
            Object.Destroy(other.gameObject);
            Player.FuelLevel = Player.FuelLevel - EnemyHitDamage;
        }
        else if (other.gameObject.CompareTag("Fuel") && Player.IsPlayerAlive)
        {
            //Debug.Log("You hit Fuel");
            Instantiate(FuelFX, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z), Quaternion.identity);
            PlayAudio.PlayOneShot(PickupSound,1.5f);
            Player.FuelLevel += FuelBoost;
            Object.Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("PointsPickup") && Player.IsPlayerAlive)
        {
            //Debug.Log("You hit Points");
            Instantiate(PointsFX, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z), Quaternion.identity);
            PlayAudio.PlayOneShot(PointsPickupSound, 1.5f);
            ScoreManager.AddPoint(50);
            Object.Destroy(other.gameObject);
        }
    }
    public void PlayHitAudio()
    {
        int AudioIndex = Random.Range(0, HitSounds.Length);
        PlayAudio.PlayOneShot(HitSounds[AudioIndex]);
    }
}
