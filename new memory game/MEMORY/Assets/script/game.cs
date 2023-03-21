using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    //add 12 public gameobjects to be added to an array to manage cards in a matching game
    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject card4;
    public GameObject card5;
    public GameObject card6;
    public GameObject card7;
    public GameObject card8;
    public GameObject card9;
    public GameObject card10;
    public GameObject card11;
    public GameObject card12;

    //array to hold the cards
    private Card[] cards;
    //array to hold the cards that are flipped
    private Card[] flippedCards;

    private IEnumerator reset;
    private IEnumerator remove;

    private bool reseting;

    








    void Start()
    {
        //use card gameobjects to make cars useing card constuctor with numbers 1-12
        Card Card1 = new Card(1, card1);
        Card Card2 = new Card(1, card2);
        Card Card3 = new Card(2, card3);
        Card Card4 = new Card(2, card4);
        Card Card5 = new Card(3, card5);
        Card Card6 = new Card(3, card6);
        Card Card7 = new Card(4, card7);
        Card Card8 = new Card(4, card8);
        Card Card9 = new Card(5, card9);
        Card Card10 = new Card(5, card10);
        Card Card11 = new Card(6, card11);
        Card Card12 = new Card(6, card12);

    
        //add cards to array
        cards = new Card[] {Card1, Card2, Card3, Card4, Card5, Card6, Card7, Card8, Card9, Card10, Card11, Card12};

        //shuffle the cards types using the Type() get / set methods in the card class
        for (int i = 0; i < cards.Length; i++)
        {
            int temp = cards[i].Type();
            int randomIndex = Random.Range(i, cards.Length);
            cards[i].Type(cards[randomIndex].Type());
            cards[randomIndex].Type(temp);
        }




        //change all cards sprite image color to a difrent color based on the card type 
        foreach (Card c in cards)
        {
            if (c.Type() == 1)
            {
                c.getGO().GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (c.Type() == 2)
            {
                c.getGO().GetComponent<SpriteRenderer>().color = Color.blue;
            }
            else if (c.Type() == 3)
            {
                c.getGO().GetComponent<SpriteRenderer>().color = Color.green;
            }
            else if (c.Type() == 4)
            {
                c.getGO().GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else if (c.Type() == 5)
            {
                c.getGO().GetComponent<SpriteRenderer>().color = Color.magenta;
            }
            else if (c.Type() == 6)
            {
                c.getGO().GetComponent<SpriteRenderer>().color = Color.cyan;
            }
        }


        flippedCards = new Card[2];
        reseting = false;



    }

    
    void Update()
    {

        if(reseting == false)
        {

            //make array of only flipped cards 
            flippedCards = null;
            flippedCards = System.Array.FindAll(cards, card => card.getGO().activeSelf == true);


            //check if there are 2 flipped cards
            
            if (flippedCards.Length == 2)
            {
                remove = removeCard();
                reset = resetCard(flippedCards[0], flippedCards[1]);

                //check if the flipped cards are the same
                if (flippedCards[0].Type() == flippedCards[1].Type())
                {
                    reseting = true;
                    StartCoroutine(remove);

                    //remove the cards from the cards array
                    cards = System.Array.FindAll(cards, card => card.getGO().activeSelf == false);
                    
                }
                else
                {
                    //if they are not the same, reset the cards
                    reseting = true;
                    StartCoroutine(reset);
                }
            }

        }




        
    }

    private IEnumerator resetCard(Card c,Card c1)
    {

        yield return new WaitForSeconds(1);
        c.getGO().SetActive(false);
        c1.getGO().SetActive(false);
        reseting = false;

    }

    private IEnumerator removeCard()
    {

        yield return new WaitForSeconds(1);

        Destroy(flippedCards[0].getGO());
        Destroy(flippedCards[1].getGO());

        Debug.Log("match removed");
        reseting = false;


    }
}
