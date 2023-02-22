using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class PlayerController
{
    private GameObject playerObject;
    private bool up;
    private bool right;
    private bool down;
    private bool left;

    //CONSTRUCTOR

    public PlayerController (GameObject player)
    {
        playerObject = player;

        up = false;
        right = false;
        down = false;
        left = false;

    }

    //MOVMENT CONTROLER

    public void Move()
    {
        CheckInput();

        int inputCount = 0;
        Vector3 direction = new Vector3(0,0,0);
        int speed = 10;

        if (up) inputCount++;
        if (right) inputCount++;
        if (down) inputCount++;
        if (left) inputCount++;




        if (inputCount > 1) 
        {
            // dont act on opposing inputs 
            // need a new solution to this 
            //if(up && down) up = false; down = false;
            //if(right && left) right = false; left = false;

            // generate diagonal direction "unit vector"
            if (up) direction = direction + new Vector3 (Mathf.Sqrt(.5f),0,0);
            if (right) direction = direction + new Vector3 (0,0,-Mathf.Sqrt(.5f));
            if (down) direction = direction + new Vector3 (-Mathf.Sqrt(.5f),0,0);
            if (left) direction = direction + new Vector3 (0,0,Mathf.Sqrt(.5f));

            playerObject.transform.Translate(direction * speed * Time.deltaTime);
            Debug.Log("move");
            

        } 
        else
        {
            if (up) direction = direction + new Vector3 (1,0,0);
            if (right) direction = direction + new Vector3 (0,0,-1);
            if (down) direction = direction + new Vector3 (-1,0,0);
            if (left) direction = direction + new Vector3 (0,0,1);

            playerObject.transform.Translate(direction * speed * Time.deltaTime);
            Debug.Log("move straight");
        }

    }




    // INPUTS

    private void CheckInput()
    {
        CheckUp();
        CheckRight();
        CheckDown();
        CheckLeft();

    }

    private void CheckUp()
    {
        up = Input.GetKey(KeyCode.UpArrow);
    }

    private void CheckRight()
    {
        right = Input.GetKey(KeyCode.RightArrow);
    }

    private void CheckDown()
    {
        down = Input.GetKey(KeyCode.DownArrow);
    }

    private void CheckLeft()
    {
        left = Input.GetKey(KeyCode.LeftArrow);
    }

    //SOUNDS

    //SPECIAL COLISTION CHECKS



    
}
