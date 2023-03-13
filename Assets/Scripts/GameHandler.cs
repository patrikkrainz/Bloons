using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject Target;
    public GameObject NoTarget;

    public GameObject[] Balloons;

    Transform spawnTransform;

    private KeyCode Start = KeyCode.Space;
    private KeyCode Quit = KeyCode.Q;

    public int Level = 1;
    public int BalloonCap;

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
                Level += 1;
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

            BalloonCap = 2 + Level;

            //weiﬂ noch nicht wie die Verschiebung funktioniert, braucht Unity.transform Typen?
            for (int i = 0; i < BalloonCap; i++)
            {
                if(i == 0)
                {
                    Instantiate(Balloons[0]);
                }
                else
                {
                    int balloonType = Random.Range(1, 3);
                    /*Vector3 position = new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f));
                    spawnTransform.position = position;
                    Instantiate(Balloons[balloonType], spawnTransform);*/
                    Instantiate(Balloons[balloonType]);
                }
            }
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
