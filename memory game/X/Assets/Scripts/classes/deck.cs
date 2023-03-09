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



    //splits deck between two players 
    public void dealPlayers (Player p1, Player p2)
    {
        int pDeckSize = 30;
        Deck tDeck1 = new Deck(pDeckSize);
        Deck tDeck2 = new Deck(pDeckSize);


        

        for (int i = 0; i < 60; i++)
        {
            if(i < pDeckSize)
            {
                //mabe use deal instead of loop index
                deck[i].getGO().transform.position = new Vector3(4.5f,0,1.5f);
                //GetComponent<RectTransform>().anchoredPosition = new Vector2(4.5f, 1.5f);
                
                tDeck1.addCard(deck[i]);
            }
            else
            {
                deck[i].getGO().transform.position = new Vector3(-4.5f,0,-1.5f);
                //GetComponent<RectTransform>().anchoredPosition = new Vector2(-4.5f, -1.5f);
                
                Debug.Log("player2 card " + (i-30));
                tDeck2.addCard(deck[i]); 
                Debug.Log(tDeck2.getTopCard());
            }
        }

        p1.giveDeck(tDeck1);
        p2.giveDeck(tDeck2);
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





/*
    public Deck()
    {
        deck = new Card[60];
        cardCount = 60;
        int[] colorCounter = new int[6] {10,10,10,10,10,10};
        int[] shapeCounter = new int[6] {10,10,10,10,10,10};
        int[] numberCounter = new int[5] {12,12,12,12,12};
        
        for (int c = 0; c < 60; c++)
        {
            int currentColor = 0;
            int currentShape = 0;
            int currentNumber = 0;


            for (int a = 0; a < 3; a++)
            {
                bool aspectFound = false;
                while (aspectFound == false)
                {
                    int roll;
                    switch (a)
                    {
                        case 0:
                            roll = Mathf.RoundToInt(Random.Range(0, colorCounter.Length));
                            if (colorCounter[roll] > 0)
                            {
                                colorCounter[roll] = colorCounter[roll] - 1;
                                currentColor = roll;
                                aspectFound = true;
                            }
                            break;
                        
                        case 1:
                            roll = Mathf.RoundToInt(Random.Range(0, shapeCounter.Length));
                            if (shapeCounter[roll] > 0)
                            {
                                shapeCounter[roll] = shapeCounter[roll] - 1;
                                currentShape = roll;
                                aspectFound = true;
                            }
                            break;

                        case 2:
                            roll = Mathf.RoundToInt(Random.Range(0, numberCounter.Length));
                            if (numberCounter[roll] > 0)
                            {
                                numberCounter[roll] = numberCounter[roll] - 1;
                                currentNumber = roll;
                                aspectFound = true;
                            }
                            break;
                        default:
                            break;            
                    }
                }
            }

            deck[c] = new Card(currentColor, currentShape, currentNumber);
            Debug.Log(c);

        }
    
    }


    //EXPIRMENTAL CONSTRUCTOR, should do the same things as the one above but better
    
    public Deck()
    {
        deck = new Card[60];
        cardCount = 60;
        string[] colors = {1, 2, 3, 4, 5, 6};
        string[] shapes = {1, 2, 3, 4, 5, 6};
        int[] numbers = {1, 2, 3, 4, 5};

        for (int c = 0; c < 60; c++)
        {
            string color = colors[c % colors.Length];
            string shape = shapes[c % shapes.Length];
            int number = numbers[c % numbers.Length];

            deck[c] = new Card(color, shape, number);
        }
    }
}
*/

