using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField]GameObject circle;
    static int seconds = 1;
    Rigidbody rigidBody;
    static float fallSpeed = -1f;
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        rigidBody.AddForce(0, fallSpeed, 0, ForceMode.Impulse);
        Invoke("SpawnCube", 1f);
    }

    void FixedUpdate()
    {
        if (Time.time % 5 == 0)
            rigidBody.AddForce(0, fallSpeed, 0, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            Destroy(gameObject);
        else if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            Destroy(circle);
        }
    }

    void SpawnCube()
    {
        if (seconds == 5)
        {
            fallSpeed += -0.5f;
            print(fallSpeed);
            seconds = 0;
        }
        print("Seconds: " + seconds);
        seconds++;
        Vector3 spawnPosition = new Vector3(Random.Range(-5.5f, 5.5f), 9f, -3.5f);
        Instantiate(this, spawnPosition, Quaternion.identity);
    }
}
