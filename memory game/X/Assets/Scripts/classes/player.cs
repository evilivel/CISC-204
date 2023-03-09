using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    //player atributes 
    private Card[] board;
    private Deck deck;
    private int boardSize = 3;
    private int dificulty;
     


    //defuat construtor: for testing, makes empty board of boardS
    public Player()
    {
        //board = new Card[boardSize];
    }


    //constructor: pass the player a deck (after its been split) deal boardSize cards to the players board
    public Player(Deck tDeck)
    {

        deck = tDeck;
        //board = new Card[boardSize];

        //deal board size to board

        /*
        for (int i=0; i<boardSize; i++)
        {
            board[i] = deck.deal();
        }
        */
        
    }


    //PLAYER MAIN METHODS

    //checks board for selected card, compairs to passed cards, returns card and removes from board
    //returns what card matched by refrence int
    //this method perfers the first card passed when compairing

    //need to be modified for checking maches, probably dosent have cards passed to it,
    //checks board for clicked cards, if match remove from board exc..
    //probably called by another function that manages "turns" 
    public Card boardCheck ()
    {
        Card tcard = null;

        for(int i = 0; i < boardSize; i++)
        {
            if (board[i].Button() == true)
            {
                if(board[i].CompCard(tcard1) == true)
                {
                    fDeckIndex = 1;
                    tcard = board[i];
                    board[i] = deck.deal();
                    return (tcard);

                }
                else if(board[i].CompCard(tcard2) == true)
                {
                    fDeckIndex = 2;
                    tcard = board[i];
                    board[i] = deck.deal();
                    return (tcard);

                }
                else
                {
                    board[i].ButtonFlip();
                }
            }
        }



        fDeckIndex = 0;
        return (tcard);
    }


    //move a card from board to 


    //deals 3 cards to board
    public void dealboard()
    {
        for (int i=0; i<boardSize; i++)
        {
            board[i] = deck.deal();

        }

    }

    public void moveboard()
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

        for (int i=0; i<boardSize; i++)
        {
            switch (i)
            {
                case 0:
                    board[i].getGO().transform.position = new Vector3(1.5f,0,currentPosition);
                break;
                case 1:
                    board[i].getGO().transform.position = new Vector3(0,0,currentPosition);
                break;
                case 2:
                    board[i].getGO().transform.position = new Vector3(-1.5f,0,currentPosition);
                break;
            }  
        }

    }


    // GET / SET METHODS

    //replaces players deck with given deck
    public Card[] getboard()
    {
        return(board);
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
