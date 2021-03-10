using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    Dropper dropper;

    void Start()
    {
        //Referencing to Dropper script for managing player death
        dropper = GameObject.FindWithTag("Enemy").GetComponent<Dropper>();
    }

    //When "Restart Button" clicks - game restarts
    public void RestartGame()
    {
        SceneManager.LoadScene("scene0");
        Time.timeScale = 1;
        Dropper.FallSpeed = -1f;
        Dropper.FallingInvokeTime = 1f;
    }

    //When "Quit Button" clicks - application closes
    public void ExitGame()
    {
        Application.Quit();
    }
}
