using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject Target;
    public GameObject NoTarget;

    private KeyCode Start = KeyCode.Space;
    private KeyCode Quit = KeyCode.Q;

    public int Level = 1;

    public static float gameTimer = 30;

    public static bool gameStarted = false;
    public static bool gameOver = false;

    void Update()
    {
        if(gameOver == false)
        {
            gameTimer -= Time.deltaTime;
        }

        if(gameTimer <= 0)
        {
            gameOver = true;
            gameTimer = 0;
        }

        if(gameOver == true)
        {
            gameStarted = false;

            GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");

            foreach (GameObject target in targets)
            {
                GameObject.Destroy(target);
            }

            if (gameTimer > 0 && gameTimer != 30)
            {
                //Level += 1;
                gameTimer = 30;
                print("You won :)");
            }
            else if(gameTimer == 0 && gameTimer != 30)
            {
                gameTimer = 30;
                print(" You lost :(");
            }

            StartCoroutine(WaitForDelay(0.5f));
        }

        if (!gameStarted && !gameOver && Input.GetKeyDown(Start))
        {
            gameStarted = true;

            Instantiate(Target);
            Instantiate(NoTarget);
            print("Created Target");

            //weiﬂ noch nicht wie die Verschiebung funktioniert, braucht Unity.transform Typen?
            /*for (int i = 0; i < Level; i++)
            {
                Instantiate(NoTarget);
            }*/
        }


        if (Input.GetKeyDown(Quit))
        {
            print("You qoit the game");
            Application.Quit();
        }
    }

    public IEnumerator WaitForDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        gameOver = false;

        StopCoroutine(WaitForDelay(delay));
    }
}
