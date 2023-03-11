using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private KeyCode Start = KeyCode.Space;
    private KeyCode Quit = KeyCode.Q;

    public float gameTimer = 30;

    public bool gameStarted = false;

    void Update()
    {
        if (!gameStarted && Input.GetKeyDown(Start))
        {
            gameStarted = true;

            //Implement balloons-spawns
        }


        if (Input.GetKeyDown(Quit))
        {
            Application.Quit();
        }
    }
}
