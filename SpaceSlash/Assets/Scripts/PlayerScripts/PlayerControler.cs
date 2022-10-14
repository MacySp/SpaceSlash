using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //Components
    private AudioSource playerAudio;
    public GameObject playerShip;

    public float speed = 30;
    private float horizontalInput;
    private float forwardInput;
    public float xRange = 10;
    public float zRangeUp = 10;
    public float zRangeDown = -10;
    public bool isAlive = true;
    GameManager game;
    [SerializeField] private FixedJoystick joystick;



    //Ship Rotation values
    public float shipRotationTime = 15f;
    float shipRotationSpeed = 0.01f;


    //Sounds
    public AudioClip playerEngine;


    // Start is called before the first frame update
    void Start()
    {
        //Iniciate Components
        playerAudio = GetComponent<AudioSource>();
        game = FindObjectOfType<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {
        Bounds();
    }
    private void FixedUpdate()
    {
        PlayerTiltAnimation();
        GetInput();
        PlayerMovement();
    }

    void PlayerTiltAnimation()
    {
        //Player's ship tilt while moving
        if (horizontalInput > 0 && game.IsPlayerAlive)
        {
            //Debug.Log("Left");
            //playerShip.transform.localRotation = Quaternion.Euler(0, 180, 30);
            playerShip.transform.localRotation = Quaternion.Lerp(playerShip.transform.rotation, Quaternion.Euler(0, 180, 30), shipRotationTime * shipRotationSpeed);
            //shipRotationTime = shipRotationTime + Time.deltaTime;
        }
        else if (horizontalInput < 0 && game.IsPlayerAlive)
        {
            //Debug.Log("Right");
            //playerShip.transform.localRotation = Quaternion.Euler(0, 180, -30);
            playerShip.transform.localRotation = Quaternion.Lerp(playerShip.transform.rotation, Quaternion.Euler(0, 180, -30), shipRotationTime * shipRotationSpeed);
            //shipRotationTime = shipRotationTime + Time.deltaTime;
        }
        else
        {
            //Debug.Log("Player is static");
            //playerShip.transform.localRotation = Quaternion.Euler(0,180,0);
            playerShip.transform.localRotation = Quaternion.Lerp(playerShip.transform.rotation, Quaternion.Euler(0, 180, 0), shipRotationTime * shipRotationSpeed);
            //shipRotationTime = (shipRotationTime + Time.deltaTime) - (shipRotationTime + Time.deltaTime);
        }
    }
    void PlayerMovement()
    {
        // Player Movement
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }
    void GetInput()
    {
        // Get input
        if (game.IsPlayerAlive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");
        }
        else
        {
            horizontalInput = 0;
            forwardInput = 0;
        }
    }
    void Bounds()
    {
        // Keeps Player In Bounds
        if (transform.position.x < -xRange) { transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); }
        if (transform.position.x > xRange) { transform.position = new Vector3(xRange, transform.position.y, transform.position.z); }
        if (transform.position.z < zRangeDown) { transform.position = new Vector3(transform.position.x, transform.position.y, zRangeDown); }
        if (transform.position.z > zRangeUp) { transform.position = new Vector3(transform.position.x, transform.position.y, zRangeUp); }
    }
}
