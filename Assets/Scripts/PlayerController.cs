using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class PlayerController : MonoBehaviour
{
    public GameObject focusedObject;

    public KeyCode Shoot = KeyCode.Space;

    void Start()
    {
        TobiiAPI.Start(null);
    }

    void Update()
    {
        GameObject focusedObjectTobii = TobiiAPI.GetFocusedObject();

        focusedObject = focusedObjectTobii;


        if (Input.GetKeyDown(Shoot))
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
        if (focusedObject != null && focusedObject.layer == 6)
        {
            print("You hit the target!");
        }
        else
        {
            print("You missed :(");
        }
    }
}
