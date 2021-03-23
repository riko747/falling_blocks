using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Block movement logic
/// </summary>
public class BlockDropper : MonoBehaviour
{
    #region Fields
    Vector3 blockSpawnPosition;

    Rigidbody rigidBody;

    //Serializing player prefab and UI
    [SerializeField] GameObject player;
    [SerializeField] GameObject menuUI;


    //Time after which cubes will accelerate
    private const int accelerationPeriod = 5;
    //Time after which method "AccelerationPreparation" will be invoked
    private const float accelerationInvokeTime = 1f;


    //Time support
    private static int seconds = 0;
    //Speed of spawning cubes
    private static float fallingInvokeTime = 1f;

    //Speed of falling cubes
    private const float obstaclesForceSpeedX = 0f;
    private static float obstaclesForceSpeedY = -1f;
    private const float obstaclesForceSpeedZ = 0f;

    //Block spawn boundaries
    private const float leftEdgeOfScreen = -5.5f;
    private const float rightEdgeOfScreen = 5.5f;
    private const float topOfScreen = 9f;
    private const float playerPositionOnZ = -3.5f;

    //Block movement acceleration support
    private static float increaseBlockFallingSpeed = -0.5f;
    private static float reduceSpawnTime = -0.05f;
    #endregion

    #region Properties

    public static int Seconds
    {
        get { return seconds; }
        set { seconds = value; }
    }

    public static float FallingInvokeTime
    {
        get { return fallingInvokeTime; }
        set { fallingInvokeTime = value; }
    }

    public float ObstaclesForceSpeedX
    {
        get { return obstaclesForceSpeedX; }
    }

    public static float ObstaclesForceSpeedY
    {
        get { return obstaclesForceSpeedY; }
        set { obstaclesForceSpeedY = value; }
    }

    public float ObstaclesForceSpeedZ
    {
        get { return obstaclesForceSpeedZ; }
    }

    public static float IncreaseBlockFallingSpeed
    {
        get { return increaseBlockFallingSpeed; }
        set { increaseBlockFallingSpeed = value; }
    }

    public static float ReduceSpawnTime
    {
        get { return reduceSpawnTime; }
        set { reduceSpawnTime = value; }
    }

    public int AccelerationPeriod
    {
        get { return accelerationPeriod; }
    }

    public float AccelerationInvokeTime
    {
        get { return accelerationInvokeTime; }
    }

    public float LeftEdgeOfScreen
    {
        get { return leftEdgeOfScreen; }
    }

    public float RightEdgeOfScreen
    {
        get { return rightEdgeOfScreen; }
    }

    public float TopOfScreen
    {
        get { return topOfScreen; }
    }

    public float PlayerPositionOnZ
    {
        get { return playerPositionOnZ; }
    }
    #endregion

    #region Methods
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        blockSpawnPosition = new Vector3(Random.Range(LeftEdgeOfScreen, RightEdgeOfScreen), TopOfScreen, PlayerPositionOnZ);

        PushObstacleOnStart();
        InvokeBlockStateMethods();
    }

    void InvokeBlockStateMethods()
    {
        Invoke("AccelerationPreparation", AccelerationInvokeTime);
        Invoke("SpawnCube", FallingInvokeTime);
    }

    void PushObstacleOnStart()
    {
        rigidBody.AddForce(ObstaclesForceSpeedX, ObstaclesForceSpeedY, ObstaclesForceSpeedZ, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            Destroy(gameObject);
        else if (collision.gameObject.tag == "Player")
            ShowGameOverScreen();
    }

    void ShowGameOverScreen()
    {
        Time.timeScale = 0;
        Destroy(player);
        menuUI.SetActive(true);
    }

    void AccelerationPreparation()
    {
        if (Seconds == AccelerationPeriod)
            SpeedUpCube();
        Seconds++;
        
    }

    
    static void SpeedUpCube()
    {
        ObstaclesForceSpeedY += IncreaseBlockFallingSpeed;
        FallingInvokeTime += ReduceSpawnTime;
        Seconds = 0;
    }

    void SpawnCube()
    {
        Instantiate(gameObject, blockSpawnPosition, Quaternion.identity);
    }
    #endregion
}
