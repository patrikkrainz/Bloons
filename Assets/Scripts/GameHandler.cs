using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject Target;
    public GameObject NoTarget;

    public GameObject[] Balloons;

    public GameObject currentBalloon;

    public Rigidbody rb;

    public Vector3 spawnPosition;
    public Vector3 force;

    private KeyCode Start = KeyCode.Space;
    private KeyCode Quit = KeyCode.Q;

    public int Level = 1;
    public int BalloonCap;
    public int TargetBalloonIndex;
    public int BalloonIndex;

    public static float gameTimer = 10;

    public float posX;
    public float posY;
    public float posZ;

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

            if (gameTimer > 0 && gameTimer != 10)
            {
                Level += 1;
                gameTimer = 10;
                print("You won :)");
            }
            else if(gameTimer == 0 && gameTimer != 10)
            {
                gameTimer = 10;
                print(" You lost :(");
            }

            StartCoroutine(WaitForDelay(0.5f));
        }

        if (!gameStarted && !gameOver && Input.GetKeyDown(Start))
        {
            gameStarted = true;

            BalloonCap = 10 + Level;

            if (BalloonCap > 20)
            {
                BalloonCap = 20;
            }

                //wei� noch nicht wie die Verschiebung funktioniert, braucht Unity.transform Typen?
                for (int i = 0; i < BalloonCap; i++)
            {
                if(i == 0)
                {
                    TargetBalloonIndex = Random.Range(0, 4);

                    force = new Vector3(Random.Range(0, 3), Random.Range(0, 3), Random.Range(0, 3));

                    posZ = Random.Range(0, 6.6f);

                    if (posZ < 1)
                    {
                        posX = Random.Range(-4.2f, 4.6f);
                        posY = Random.Range(-1, 3);
                    }
                    else if (posZ >= 1 && posZ < 2)
                    {
                        posX = Random.Range(-5.4f, 5.8f);
                        posY = Random.Range(-1, 3);
                    }
                    else if (posZ >= 2 && posZ < 3)
                    {
                        posX = Random.Range(-6.6f, 7);
                        posY = Random.Range(-1, 3);
                    }
                    else if (posZ >= 3 && posZ < 4)
                    {
                        posX = Random.Range(-7.8f, 8.2f);
                        posY = Random.Range(-1, 3);
                    }
                    else if (posZ >= 4 && posZ < 5)
                    {
                        posX = Random.Range(-9, 9.4f);
                        posY = Random.Range(-1, 3);
                    }
                    else if (posZ >= 5 && posZ < 6)
                    {
                        posX = Random.Range(-10.2f, 10.6f);
                        posY = Random.Range(-1, 3);
                    }

                    spawnPosition = new Vector3(posX, posY, posZ);
                    currentBalloon = Instantiate(Balloons[TargetBalloonIndex], spawnPosition, Quaternion.identity);
                    currentBalloon.layer = 6;
                    rb = currentBalloon.GetComponent<Rigidbody>();
                    rb.AddForce(force);
                }
                else
                {
                    BalloonIndex = Random.Range(0, 4);

                    if(BalloonIndex == TargetBalloonIndex)
                    {
                        BalloonIndex = Random.Range(1, 4);
                        i-=1;
                    }
                    else
                    {
                        force = new Vector3(Random.Range(0, 3), Random.Range(0, 3), Random.Range(0, 3));

                        posZ = Random.Range(0, 6.6f);

                        if (posZ < 1)
                        {
                            posX = Random.Range(-4.2f, 4.6f);
                            posY = Random.Range(-1, 3);
                        }
                        else if (posZ >= 1 && posZ < 2)
                        {
                            posX = Random.Range(-5.4f, 5.8f);
                            posY = Random.Range(-1, 3);
                        }
                        else if (posZ >= 2 && posZ < 3)
                        {
                            posX = Random.Range(-6.6f, 7);
                            posY = Random.Range(-1, 3);
                        }
                        else if (posZ >= 3 && posZ < 4)
                        {
                            posX = Random.Range(-7.8f, 8.2f);
                            posY = Random.Range(-1, 3);
                        }
                        else if (posZ >= 4 && posZ < 5)
                        {
                            posX = Random.Range(-9, 9.4f);
                            posY = Random.Range(-1, 3);
                        }
                        else if (posZ >= 5 && posZ < 6)
                        {
                            posX = Random.Range(-10.2f, 10.6f);
                            posY = Random.Range(-1, 3);
                        }

                        spawnPosition = new Vector3(posX, posY, posZ);
                        currentBalloon = Instantiate(Balloons[BalloonIndex], spawnPosition, Quaternion.identity);
                        rb = currentBalloon.GetComponent<Rigidbody>();
                        rb.AddForce(force);
                    }
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
