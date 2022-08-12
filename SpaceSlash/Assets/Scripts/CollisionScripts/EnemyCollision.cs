using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    //Gameobjects
    [SerializeField] private GameObject[] ExplosionsFX;
    [SerializeField] private GameObject[] PowerUpAsset;
    private ScoreManager ScoreManager;





    private void Awake()
    {
        ScoreManager = FindObjectOfType<ScoreManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        //Detect Collision from drifferent tags of different colliders
        if (other.gameObject.CompareTag("Asteroid"))
        {

        }
        else if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Enemy touched player");
            Destroy(gameObject);
            Instantiate(ExplosionsFX[Random.Range(0, PowerUpAsset.Length)], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
        else if (this.CompareTag("Enemy") && other.gameObject.CompareTag("PlayerProjectile"))
        {
            PowerUpSpawn(1,3);
            //Debug.Log("Projectile hit the enemy");
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(ExplosionsFX[Random.Range(0, PowerUpAsset.Length)], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            //add points
            ScoreManager.AddPoint(10);
        }
        else if (this.CompareTag("Asteroid") && other.gameObject.CompareTag("PlayerProjectile"))
        {
            PowerUpSpawn(2,5);
            //Debug.Log("Projectile hit the Asteroid");
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(ExplosionsFX[Random.Range(0, PowerUpAsset.Length)], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            //add points
            ScoreManager.AddPoint(5);
        }
        else if (this.CompareTag("Enemy2") && other.gameObject.CompareTag("PlayerProjectile"))
        {
            PowerUpSpawn(1,1);
            //Debug.Log("Projectile hit the enemy");
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(ExplosionsFX[Random.Range(0, PowerUpAsset.Length)], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            //add points
            ScoreManager.AddPoint(20);
        }
    }

    //Power ups spawn
    private void PowerUpSpawn(int PowerUp, int SpawnRate)
    {
        if (Random.Range(1, SpawnRate) == PowerUp)
        {
            Instantiate(PowerUpAsset[Random.Range(0,PowerUpAsset.Length)], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
