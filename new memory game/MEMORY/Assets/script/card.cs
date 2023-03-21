using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card
{
    private int type;
    private GameObject GO;
    private bool selected;


    public Card(int t, GameObject g)
    {
        type = t;
        GO = g;

    }


    //GET SET

    public int Type()
    {
        return(type);
    }
    public void Type(int t)
    {
        type = t;
    }

    public GameObject getGO()
    {
        if (GO != null)
        {
            return(GO);
        }
        else
        {
            return(null);
        }
            
        
    }


}
