using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Restarting level and exiting application logic
/// </summary>
public class GameOverScreen : MonoBehaviour
{
    //When "Restart Button" clicks - game restarts
    public void RestartGame()
    {
        SceneManager.LoadScene("scene0");
        Time.timeScale = 1;
        BlockDropper.ObstaclesForceSpeedY = -1f;
        BlockDropper.FallingInvokeTime = 1f;
    }

    //When "Quit Button" clicks - application closes
    public void ExitGame()
    {
        Application.Quit();
    }
}
