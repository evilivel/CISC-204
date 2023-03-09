using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Table
{
    private Deck tableDeck;
    private Card[,] board;
    
    private bool gameOver;
    
    private Canvas canvas;
    private int columns;
    private int rows;

    private const float posX = 0;
    private const float posY = 0;
    private const float offset = 2;

    private float turnTime;
    private int sight;
    private int hp;
    private int score;
    private int multi;

    



    public Table(Canvas canvass)
    {
       canvas  = canvass;
       board = new Card[rows, columns];

       gameOver  = false;

       Card tempCard = null;

       columns = 5;
       rows = 4;

       turnTime = 5;
       hp = 100;
       score = 0;
       multi = 1;
       sight = 1;

       tableDeck = new Deck(canvas);
        
        //NEED TP LOAD CARDS IN TO ARRAY FROM DECK AND MOVE THE GAMEOBJECT ONTO FIELD 
        for(int c = 0; c < rows; c++)
        {
            for(int r = 0; r < columns; r++)
            {
                tempCard = tableDeck.deal();
                board[r,c] = tempCard;
                tempCard.getGO().transform.position = new Vector3((posX + offset * c), 0 ,(posY + offset * c));
                
            }
        }
       
        
    }
    
    //"player1Play"
    // checks if turn timer is above 0, if two cards have been fliped
    // checks if two cards match, if so, do effect, if not lose 10 health 
    //remove matched cards, adjust score, shift cards down, deal new cards, reset turn time 

    //STEAL SOME OF THIS CODE FOR CARD CLASS "LOCKOUT" FLIPING CARDS
    public void turncheck()
    {
        int tRow = 0;
        int tColumn = 0;
        int cardsClicked = 0;

        Vector3 discard = new Vector3 (0,0,0);
        Card tempCard = null;

        //need line to update turn time on UI for player

        if(turnTime > 0)
        {
            for(int r = 0; r < rows; r++)
            {
                for(int c = 0; c < columns; c++)
                {
                    if (board[r,c].Button() == true)
                    {
                        cardsClicked++;
                        
                        if (cardsClicked > sight)
                        {
                            if(board[tRow,tColumn].Type() ==  board[r,c].Type())
                            {
                                switch(board[r,c].Type())
                                {
                                    case 1:
                                        hp += (board[tRow,tColumn].Number() + board[r,c].Number()) * multi;
                                    break;

                                    case 2:
                                        multi += (board[tRow,tColumn].Number() + board[r,c].Number());
                                    break;

                                    default:
                                        Debug.Log("invalid card type");
                                    break;
                                } 

                                board[tRow,tColumn].getGO().transform.position = discard;
                                board[r,c].getGO().transform.position = discard;

                                board[tRow,tColumn]=null;
                                board[r,c]=null;

                                score += 100 * multi;
                            }
                            else
                            {
                                board[tRow,tColumn].ButtonFlip();
                                board[r,c].ButtonFlip();

                                hp -= 10;
                            }

                            //need to fix this to some vaule i can change
                            turnTime = 5;
                            
                        }
                        else
                        {
                            tRow = r;
                            tColumn = c;

                        }

                    }
                }
            }
        }
        else
        {
            hp -= 10;
            turnTime = 5;
        }

        //CODE FOR SHIFTING CARDS DOWN AND DEALING 
        //WOULD LIKE SOME WAY OF ANIMATING CARD MOVMENT 
        //if board spot is empty, copy card above it and remove that card, move back to new empty slot to check for cards above it 
        //MIGHT MAKE BUG WHERE GOES OFF THE END OF ARRAY AT TOP

        for(int c = 0; c < columns; c++)
        {
            for(int r = 1; r < rows; r++)
            {

                if(board[r,c] == null)
                {
                    board[r,c] = board[r-1,c];
                    board[r-1,c] = null;
                    board[r,c].getGO().transform.position = new Vector3((posX + offset * c), 0 ,(posY + offset * c));
                    r = r-2;
                }

            }
        }

        //goes bottom up in columb through rows, checks if spot is empty, is so deal card 
        for(int c = 0; c < columns; c++)
        {
            for(int r = rows-1; r >= 0; r--)
            {
                if(board[r,c] == null)
                {
                    board[r,c] = tableDeck.deal();
                    board[r,c].getGO().transform.position = new Vector3((posX + offset * c), 0 ,(posY + offset * c));
                }

            }
        }


    }


    


    //NEEDS TO CHECK IF LIFE IS BELOW 0 OR IF THERE ARE NO MORE CARDS 
    public bool checkGameOver(ref bool Win1)
    {
        int DeckSize = tableDeck.getCardCount();
        bool fieldEmpty = false;

        for(int r = 0; r < rows; r++)
            {
                for(int c = 0; c < columns; c++)
                { 
                    if(board[r,c] != null)
                    {
                        r = rows;
                        c = columns;
                        fieldEmpty = false;
                    }
                    else if(r == rows - 1 && c == columns - 1)
                    {
                        fieldEmpty = true;
                    } 
                
                }
            }



        if(gameOver == false)
        {
            if(DeckSize < 1 && fieldEmpty)
            {
                gameOver = true;
                Debug.Log("Game Over");
                Debug.Log("no more cards");
                Win1 = true;




            }
            if(hp <= 0)
            {
                gameOver = true;
                Debug.Log("Game Over");
                Debug.Log("no more hp");
            }



        }
        

        return (gameOver);
    }
    


}
