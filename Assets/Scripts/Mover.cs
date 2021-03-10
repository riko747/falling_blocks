using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    
    //Player movement speed
    float speed;

    //Half screen detection
    double halfScreen;

    void Start()
    {
        speed = 5 * Time.deltaTime;
        halfScreen = Screen.width / 2;
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            //If player touches left edge of screen, player moves left
            if (touchPosition.x < halfScreen)
                transform.Translate(Vector3.left * speed);
            //If player touches right edge of screen, player moves right
            else if (touchPosition.x > halfScreen)
                transform.Translate(Vector3.right * speed);
        }
    }
}
