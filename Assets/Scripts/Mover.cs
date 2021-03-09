using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Vector3 moveLeft, moveRight;

    float x;
    void Start()
    {
        x = 5 * Time.deltaTime;
        moveLeft = new Vector3(-x, 0, 0);
        moveRight = new Vector3(x, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) //&& Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            double halfScreen = Screen.width / 2.0;

            if (touchPosition.x < halfScreen)
            {
                transform.Translate(Vector3.left * 5f * Time.deltaTime);
            }
            else if (touchPosition.x > halfScreen)
            {
                transform.Translate(Vector3.right * 5f * Time.deltaTime);
            }
        }
    }
}
