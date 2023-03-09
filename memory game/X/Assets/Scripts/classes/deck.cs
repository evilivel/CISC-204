using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Security.Cryptography;

public class Deck
{

    //{"red", "yellow", "green", "blue", "purple", "grey"}
    //{"triangle", "diamond", "circle", "bolt", "star", "x"}
     
    private Card[] deck;
    private int cardCount;
    
    //constructor, returns deck of correct cards, 10 of each color / shape and 12 of each number 
    public Deck()
    {
        Object[] textures = Resources.LoadAll("cards", typeof(Texture2D));
        deck = new Card[60];
        cardCount = 59;

        
        for (int c = 0; c < 60; c++)
        {
            deck[c] = new Card(textures[c]);
            
            Debug.Log(c);

        }

        //might need to move cards on field 
    
    }

    public Deck(Canvas canvas)
    {
        Object[] textures = Resources.LoadAll("cards", typeof(Texture2D));
        deck = new Card[60];
        cardCount = 59;

        
        Object tempGO;

        for (int i = 0; i < textures.Length; i++) 
        {
             int rnd = Random.Range(0, textures.Length);
             tempGO = textures[rnd];
             textures[rnd] = textures[i];
             textures[i] = tempGO;
        }


        
        for (int c = 0; c < 60; c++)
        {
            deck[c] = new Card(textures[c],canvas);
            
            Debug.Log(c);

        }

        //might need to move cards on field 
    
    }





    //simplified constructor with vairable size
    public Deck(int size)
    {
        deck = new Card[size];
        cardCount = 0;
    }


    //MAIN DECK METHODS
    

    //adds card to top of deck
    public void addCard(Card card)
    {
        if (deck[cardCount] == null)
        {
            deck[cardCount] = card;
        }
        else
        {
            cardCount = cardCount + 1;
            deck[cardCount] = card;
        }

    }

    //return top card of deck then remove it 
    public Card deal()
    {
        if (cardCount >= 0)
        {
            Card topCard = deck[cardCount];
            deck[cardCount] = null;
            cardCount = cardCount - 1;
            return(topCard);

        }
        else
        {
            Debug.Log("help");
            return(null);
        }

        
    }





    // GET / SET METHODS

    public Card getTopCard()
    {
        return(deck[cardCount]);
    }


    //PROBABLY SHOULDNT BE USED: USE ADDCARD AND DEAL INSTEAD
    
    //sets the deck index
    public void setCardCount(int count)
    {
        cardCount = count;

    }
    //gets the deck index 
    public int getCardCount()
    {
        return(cardCount);
    }



    

    



}






