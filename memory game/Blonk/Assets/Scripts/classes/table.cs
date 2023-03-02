using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Table
{
    private Deck tableDeck1;
    //private Deck tableDeck2;

    private Player player1;
    //private Player player2;

    private bool gameOver;
    private int fDeckIndex;

    private Canvas canvas;



    public Table(Canvas canvass)
    {
       canvas  = canvass;
       gameOver  = false;
       tableDeck1 = new Deck(60);
       tableDeck2 = new Deck(60);
       player1 = new Player(1);
       player2 = new Player(2);

       // creates a new deck using defult constructor and splits it between two players 
       new Deck(canvas).dealPlayers(player1, player2);

       //fills both players hand
       player1.dealHand();
       player2.dealHand();
       player1.moveHand();
       player2.moveHand();

       //move top card of each player deck to table deck 
       Card tCard1 = player1.getDeck().deal();
       Card tCard2 = player2.getDeck().deal();

       tableDeck1.addCard(tCard1);
       tableDeck2.addCard(tCard2);

       tCard1.getGO().transform.position = new Vector3(1,0,-.5f);
       tCard2.getGO().transform.position = new Vector3(-1,0,-.5f);
        
    }
    

    // method that playes selected card onto correct deck if they match
    public void player1Play()
    {
        Card currentCard = player1.handCheck(tableDeck1.getTopCard(), tableDeck2.getTopCard(), ref fDeckIndex);
        player1.moveHand();

        if(fDeckIndex == 1)
        {
            currentCard.getGO().transform.position = new Vector3(1,0,-.5f);
            tableDeck1.getTopCard().getGO().SetActive(false);
            tableDeck1.addCard(currentCard);
        }
        else if (fDeckIndex == 2)
        {
            currentCard.getGO().transform.position = new Vector3(-1,0,-.5f);
            tableDeck2.getTopCard().getGO().SetActive(false);
            tableDeck2.addCard(currentCard);
        }

        // if no cards where selected or the card did not match the top card of either deck
        //do nothing

    }

    public void player2Play()
    {


            Card currentCard = player2.handCheck(tableDeck1.getTopCard(), tableDeck2.getTopCard(), ref fDeckIndex);
            player2.moveHand();

            if(fDeckIndex == 1)
            {
                currentCard.getGO().transform.position = new Vector3(1,0,-.5f);
                tableDeck1.getTopCard().getGO().SetActive(false);
                tableDeck1.addCard(currentCard);
            }
            else if (fDeckIndex == 2)
            {
                currentCard.getGO().transform.position = new Vector3(-1,0,-.5f);
                tableDeck2.getTopCard().getGO().SetActive(false);
                tableDeck2.addCard(currentCard);
            }

        
    }


    //checks if either players deck is empty, returns true if game is over and false if it is not
    // just relized i should add something to check if the hand is empty as well 
    public bool checkGameOver(ref bool Win1, ref bool Win2)
    {
        int p1DeckSize = player1.getDeck().getCardCount(); 
        int p2DeckSize = player2.getDeck().getCardCount();
        if(gameOver == false)
        {
            if(p1DeckSize < 1)
            {
                gameOver = true;
                Debug.Log("Game Over");
                Debug.Log("player 1 wins");
                Win1 = true;




            }

            if(p2DeckSize < 1)
            {
                gameOver = true;
                Debug.Log("Game Over");
                Debug.Log("player 2 wins");
                Win2 = true;

                //SCENE CHANGE********************



            }

        }
        

        return (gameOver);
    }
    
    // probably need to add method to check if either player has a playable card (check if game is stuck and deal card from one of the players decks to unstick it)
    public Player getPlayer()
    {
        return(player2);
    }

    /*

                GameObject gameOverButton = new GameObject("button");
                RectTransform trans = gameOverButton.AddComponent<RectTransform>();
                gameOverButton.AddComponent<Button>();
                gameOverButton.GetComponent<Button>().onClick.AddListener(TaskOnClick);
                trans.transform.SetParent(canvas.transform); // setting parent
                trans.localScale = Vector3.one;
                trans.anchoredPosition = new Vector2(0f, 0f); // setting position, will be on center
                trans.sizeDelta= new Vector2(125, 175); // custom size
                trans.transform.localRotation = Quaternion.Euler(0, 0, 0);
                
                Text stuff = gameOverButton.AddComponent<Text>();
                
                stuff.text = "BUTTS";

                gameOverButton.transform.SetParent(canvas.transform);

        void TaskOnClick()
    {
        
        Debug.Log("You have clicked the button!!!!!!!!!!!!");
    }
*/

}
