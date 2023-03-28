using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class PlayerController : MonoBehaviour
{
    public GameObject focusedObject;
    public GameObject prevObject;

    public KeyCode Shoot = KeyCode.Space;

    public static bool noDart;

    void Start()
    {
        TobiiAPI.Start(null);
    }

    void Update()
    {
        GameObject focusedObjectTobii = TobiiAPI.GetFocusedObject();

        focusedObject = focusedObjectTobii;

        if(focusedObject != null && focusedObject != prevObject)
        {
            prevObject = focusedObject;
        }

        if (GameHandler.gameStarted && Input.GetKeyDown(Shoot))
        {
            ManageShots();
        }


        //Checking if objects get focused

        /*if (focusedObjectTobii != null)
        {
            print("The focused game object is: " + focusedObject.name);
        }
        else
        {
            print("No Object focused");
        }*/
    }

    public void ManageShots()
    {
        if (!noDart)
        {
            if (focusedObject != null && focusedObject.layer == 6)
            {
                Object.Destroy(focusedObject);
                focusedObject = null;
                prevObject = null;
                //GameObject.Destroy(GameHandler.currentDart);
                //noDart = true;
                GameHandler.gameOver = true;
                print("You hit the target!");
            }
            else if (focusedObject != null && focusedObject.layer == 7)
            {
                Object.Destroy(focusedObject);
                focusedObject = null;
                prevObject = null;
                //GameObject.Destroy(GameHandler.currentDart);
                //noDart = true;
                GameHandler.gameTimer -= 3;
                print("You missed :(");
            }
            else
            {
                //GameObject.Destroy(GameHandler.currentDart);
                //noDart = true;
                GameHandler.gameTimer -= 3;
                print("You missed :(");
            }
        }
    }
}
