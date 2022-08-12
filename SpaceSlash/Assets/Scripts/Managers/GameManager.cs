using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PlayerDeathFX;
    [SerializeField] GameObject PlayerShip;
    [SerializeField] GameObject GameOverScreen;
    SpawnManager SpawnManager;

    [SerializeField] private readonly float FuelBurningRate = 1f;
    [SerializeField] private float NextWave = 5;
    private float SpawnRate1;
    private float SpawnRate2;
    private float TimePassing;
    public float FuelLevel = 100f;
    public bool IsPlayerAlive = true;

    // Start is called before the first frame update
    private void Awake()
    {
        SpawnManager = FindObjectOfType<SpawnManager>();
    }

    void Start()
    {
        SpawnRate1 = SpawnManager.MinInterval;
        SpawnRate2 = SpawnManager.MaxInterval;
        TimePassing = 0;
    }


    void Update()
    {
        TimePassing = 1 * (int)Time.timeSinceLevelLoad;

        //Constantly decrease fuel level through time
        if (IsPlayerAlive)
        {
            FuelLevel -= Time.deltaTime * FuelBurningRate;
        }
        //keep FuelBar in range
        if (FuelLevel > 100f)
        {
            FuelLevel = 100f;
        }
        //PlayerDeath After reaching fuel level 0
        else if (FuelLevel <= 0f && IsPlayerAlive)
        {
            FuelLevel = 0;
            //Debug.Log("You're Dead");
            IsPlayerAlive = false;
            Instantiate(PlayerDeathFX, new Vector3(PlayerShip.transform.position.x, PlayerShip.transform.position.y, PlayerShip.transform.position.z), Quaternion.identity);
            PlayerShip.SetActive(false);

            SpawnManager.IsActive = false;
            GameOverScreen.SetActive(true);
            GameOverScreen.GetComponent<GameOverScreen>().PrintScore();

        }

        //Difficulty over time

        if (TimePassing >= NextWave)
        {
            NextWave = TimePassing + 1;
            SpawnManager.ChangeSpawnRate(0.01f);
            //Debug.Log(TimePassing);
        }

        //Adding E2_Ship
        if (TimePassing == 15f) {
            SpawnManager.EnemyMaxIndex = 2;
        }

        //Adding E3_Ship
        if (TimePassing == 30f)
        {
            SpawnManager.EnemyMaxIndex = 3;
        }

    }

}
