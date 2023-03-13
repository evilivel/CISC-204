using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card
{

    // CARDS NEED TO HAVE BUTTONS ON THEM THAT CAN RUN A SCRIPT (MAKE CARDS CLICKABLE)

    //card atributes 
    private int type;
    private int number;

    private GameObject back;
    private GameObject GO;
    private bool buttonPressed;


    //These arrays of the posible shapes and colors gives me more options for constructors 
    private string[] types = new string[6] {"hp", "multi", "empty", "empty", "empty", "empty"};
    private string[] numbers = new string[6] {"1", "2", "3", "10", "20","30"};

    
    
    
    //defult construtor: random stats, only used for testing
    public Card()
    {


        type = Mathf.RoundToInt(Random.Range(0, 6));
        number = Mathf.RoundToInt(Random.Range(1, 6));
        

    }

    //consturtor: this one does all the image BS without canvas 
    public Card(Object texture)
    {
        string[] words = texture.name.Split(' ');
        foreach (var i in words)
        {
            for (int a = 0; a < 6; a++)
            {
                if (types[a] == i)
                {
                    type = a;
                }

                if (numbers[a] == i)
                {
                    number = a;
                }

            }
        }

      



        Texture2D Texture = (Texture2D)texture;
        GO = GameObject.CreatePrimitive(PrimitiveType.Plane);
        GO.transform.localScale = new Vector3(.14f,.14f,.2f);
        
        
        GO.GetComponent<Renderer>().material.mainTexture = Texture;

        
    }

    //consturtor: this one does all the image BS with canvas 
    public Card(Object texture, Canvas canvas)
    {
        string[] words = texture.name.Split(' ');
        foreach (var i in words)
        {
            for (int a = 0; a < 6; a++)
            {
                if (types[a] == i)
                {
                    type = a+1;
                }

                if (numbers[a] == i)
                {
                    number = int.Parse(numbers[a]);
                }

            }
            if(i == "-")
            {
                
                number = -number;
                Debug.Log(number);
                break;
            }
        }

       

      

        GameObject imgObject = new GameObject("card");
        


        RectTransform trans = imgObject.AddComponent<RectTransform>();
        imgObject.AddComponent<Button>();
        imgObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        trans.transform.SetParent(canvas.transform); // setting parent
        trans.localScale = Vector3.one;
        trans.anchoredPosition = new Vector2(0f, 0f); // setting position, will be on center
        trans.sizeDelta= new Vector2(115, 155); // custom size
        trans.transform.localRotation = Quaternion.Euler(0, 0, 0);

        Image image = imgObject.AddComponent<Image>();
        Texture2D tex = (Texture2D)texture;
        image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        imgObject.transform.SetParent(canvas.transform);

       

        back = imgObject;

        GO = imgObject;


        
    }
    

    //MAIN CARD METHODS







    //GET / SET METHODS




    //returns game object
    public GameObject getGO()
    {
        return (GO);
    }

    // return color of card

    public bool Button()
    {
        return(buttonPressed);
    }

    public void Back(Object texture)
    {
        Image image = back.GetComponent<Image>();
        Texture2D tex = (Texture2D)texture;
        image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));

        //GO.SetActive(false);
        //back.SetActive(true);
    }
    

    
    //return shape of card

    public int Type()
    {
        return (type);
    }

    //return number of card
    
    public int Number()
    {
        return (number);
    }

    // sets true if false and false if true (toggle)
    public void ButtonFlip()
    {
        if (buttonPressed == true)
        {
            System.Threading.Thread.Sleep(1000);
            buttonPressed = false;
            //GO.SetActive(false);
            back.SetActive(true);
        }
        else
        {
            buttonPressed = true;
            Debug.Log(number);

            back.SetActive(false);
            
        }
    }

    void TaskOnClick()
    {
        ButtonFlip();

        //Debug.Log("You have clicked the button!");
    }







}
