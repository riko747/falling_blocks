using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player movement logic
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    #region Fields
    Vector2 screenTouchPosition;

    //Player movement speed
    private const float playerMovementSpeed = 5f;

    //Screen touching detection
    private bool playerTouchesScreen;
    private bool playerTouchesLeftEdgeOfScreen;
    private bool playerTouchesRightEdgeOfScreen;

    //Half screen calculation
    private double halfScreen;
    #endregion

    #region Properties

    public Vector2 ScreenTouchPosition
    {
        get { return screenTouchPosition; }
        set { screenTouchPosition = value; }
    }
    public double HalfScreen
    {
        get { return halfScreen; }
        set { halfScreen = value; }
    }
    public bool PlayerTouchesScreen
    {
        get { return playerTouchesScreen; }
        set { playerTouchesScreen = value; }
    }
    public bool PlayerTouchesLeftEdgeOfScreen
    {
        get { return playerTouchesLeftEdgeOfScreen; }
        set { playerTouchesLeftEdgeOfScreen = value; }
    }
    public bool PlayerTouchesRightEdgeOfScreen
    {
        get { return playerTouchesRightEdgeOfScreen; }
        set { playerTouchesRightEdgeOfScreen = value; }
    }

    public float PlayerMovementSpeed
    {
        get { return playerMovementSpeed; }
    }
    #endregion

    #region Methods
    void Start()
    {
        HalfScreen = Screen.width / 2;
    }

    void Update()
    {
        PlayerTouchesScreen = Input.touchCount > 0;

        if (PlayerTouchesScreen)
            CheckTouchPosition();
    }

    void CheckTouchPosition()
    {
        ScreenTouchPosition = Input.GetTouch(0).position;
        PlayerTouchesLeftEdgeOfScreen = ScreenTouchPosition.x < HalfScreen;
        PlayerTouchesRightEdgeOfScreen = ScreenTouchPosition.x > HalfScreen;

        if (PlayerTouchesLeftEdgeOfScreen)
            MoveLeft();
        else if (PlayerTouchesRightEdgeOfScreen)
            MoveRight();
    }

    void MoveLeft()
    {
        transform.Translate(Vector3.left * PlayerMovementSpeed * Time.deltaTime);
    }

    void MoveRight()
    {
        transform.Translate(Vector3.right * PlayerMovementSpeed * Time.deltaTime);
    }
    #endregion
}
