using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    #region Fields
    
    Rigidbody rigidBody;

    //Serializing player prefab and UI
    [SerializeField] GameObject player;
    [SerializeField] GameObject menu;

    //Time support
    private static int seconds = 0;
    //Speed of spawning cubes
    private static float fallingInvokeTime = 1f;
    //Speed of falling cubes
    private static float fallSpeed = -1f;
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

    public static float FallSpeed
    {
        get { return fallSpeed; }
        set { fallSpeed = value; }
    }

    #endregion

    #region Methods
    void Start()
    {
        //Initial Force
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(0, fallSpeed, 0, ForceMode.Impulse);

        Invoke("AccelerationSupport", 1f);
        Invoke("SpawningCube", fallingInvokeTime);
    }

    //Block will be destroyed when it touches the ground
    //If block touches player - player will be destroyed
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            Destroy(gameObject);
        else if (collision.gameObject.tag == "Player")
            ShowGameOverScreen();
    }

    //Gameover UI appears when player died
    void ShowGameOverScreen()
    {
        Time.timeScale = 0;
        Destroy(player);
        menu.SetActive(true);
    }

    void AccelerationSupport()
    {
        if (seconds == 5)
            Speedup();
        seconds++;
        
    }

    //When 5 seconds elapses speed of cubes increases
    static void Speedup()
    {
        fallSpeed += -0.5f;
        fallingInvokeTime -= 0.05f;
        seconds = 0;
    }

    //Spawning new cube at random position on top of the screen
    void SpawningCube()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-5.5f, 5.5f), 9f, -3.5f);
        Instantiate(gameObject, spawnPosition, Quaternion.identity);
    }
    #endregion
}
