using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    //player atributes 
    private Card[] hand;
    private Deck deck;
    private int handSize = 3;
    private int dificulty;
     


    //defuat construtor: for testing, makes empty hand of handS
    public Player()
    {
        //hand = new Card[handSize];
    }


    //constructor: pass the player a deck (after its been split) deal handSize cards to the players hand
    public Player(Deck tDeck)
    {

        deck = tDeck;
        //hand = new Card[handSize];

        //deal hand size to hand

        /*
        for (int i=0; i<handSize; i++)
        {
            hand[i] = deck.deal();
        }
        */
        
    }


    //PLAYER MAIN METHODS

    //checks hand for selected card, compairs to passed cards, returns card and removes from hand
    //returns what card matched by refrence int
    //this method perfers the first card passed when compairing
    public Card handCheck (Card tcard1, Card tcard2, ref int fDeckIndex)
    {
        Card tcard = null;

        for(int i = 0; i < handSize; i++)
        {
            if (hand[i].Button() == true)
            {
                if(hand[i].CompCard(tcard1) == true)
                {
                    fDeckIndex = 1;
                    tcard = hand[i];
                    hand[i] = deck.deal();
                    return (tcard);

                }
                else if(hand[i].CompCard(tcard2) == true)
                {
                    fDeckIndex = 2;
                    tcard = hand[i];
                    hand[i] = deck.deal();
                    return (tcard);

                }
                else
                {
                    hand[i].ButtonFlip();
                }
            }
        }



        fDeckIndex = 0;
        return (tcard);
    }


    //move a card from hand to 


    //deals 3 cards to hand
    public void dealHand()
    {
        for (int i=0; i<handSize; i++)
        {
            hand[i] = deck.deal();

        }

    }

    public void moveHand()
    {
        int side1Position = 2;
        int side2Position = -3;
        int currentPosition;

        if(side == 1)
        {
            currentPosition = side1Position;
        }
        else
        {
            currentPosition = side2Position;
        }

        for (int i=0; i<handSize; i++)
        {
            switch (i)
            {
                case 0:
                    hand[i].getGO().transform.position = new Vector3(1.5f,0,currentPosition);
                break;
                case 1:
                    hand[i].getGO().transform.position = new Vector3(0,0,currentPosition);
                break;
                case 2:
                    hand[i].getGO().transform.position = new Vector3(-1.5f,0,currentPosition);
                break;
            }  
        }

    }


    // GET / SET METHODS

    //replaces players deck with given deck
    public Card[] getHand()
    {
        return(hand);
    }


    public void giveDeck(Deck tDeck)
    {
        deck = tDeck;
    }

    public Deck getDeck()
    {
        return(deck);
    }


}
