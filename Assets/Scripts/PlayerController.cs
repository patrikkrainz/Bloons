using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class PlayerController : MonoBehaviour
{
    private GazePoint gazePoint;

    public KeyCode Shoot = KeyCode.Space;

    public float viewX;
    public float viewY;

    void Start()
    {
        
    }

    void Update()
    {
        ManageGazePoint();

        if (Input.GetKeyDown(Shoot))
        {
            ManageShots(viewX, viewY);
        }
    }


    public void ManageGazePoint()
    {
        gazePoint = TobiiAPI.GetGazePoint();

        viewX = gazePoint.Screen.x;
        viewY = gazePoint.Screen.y;
    }

    public void ManageShots(float viewX, float viewY)
    {
        if (true)
        {
            return;
        }
    }
}
