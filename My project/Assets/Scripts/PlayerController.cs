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

    public float mouseSensitivity = 100f;
    

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
        int speed = 7;

        // dont act on opposing inputs 
        //this need to be here to avoid using the diagonal imput code 
        //when it is not needed, it seems to work but when pressing left and right
        //you can only go back and with up and down you can only go right
        //i have no clue why this is, please help 



        if(up && down) 
        {
            up = false; 
            down = false;
        }
        
        if(right && left) 
        {
            right = false; 
            left = false;
        }

        if (up) inputCount++;
        if (right) inputCount++;
        if (down) inputCount++;
        if (left) inputCount++;


        if (inputCount > 1) 
        {


            // generate diagonal direction "unit vector"
            if (up) direction = direction + new Vector3 (0,0,Mathf.Sqrt(.5f));
            if (right) direction = direction + new Vector3 (Mathf.Sqrt(.5f),0,0);
            if (down) direction = direction + new Vector3 (0,0,-Mathf.Sqrt(.5f));
            if (left) direction = direction + new Vector3 (Mathf.Sqrt(.5f),0,0);

            playerObject.transform.Translate(direction * speed * Time.deltaTime);
            Debug.Log("move");
            

        } 
        else
        {
            if (up) direction = direction + new Vector3 (0,0,1);
            if (right) direction = direction + new Vector3 (1,0,0);
            if (down) direction = direction + new Vector3 (0,0,-1);
            if (left) direction = direction + new Vector3 (-1,0,0);

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
