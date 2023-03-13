using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Main : MonoBehaviour
{
    

    public Canvas canvas;
    public Table currentTable;
    public bool GameEnded;

    public bool Win1;
    public bool Win2;


    public GameObject winMenu;
    public GameObject loseMenu;

    public Object texture;


    // Start is called before the first frame update
    void Start()
    {
        GameEnded = false;
        canvas = gameObject.GetComponent<Canvas>();
        currentTable = new Table(canvas,texture);

    }

    // Update is called once per frame
    void Update()
    {
      
      currentTable.turncheck();
      
      if(currentTable.checkGameOver(ref Win1, ref Win2) == true)
      {
        //Debug.Log("Game Over");
        GameEnded = true;
        if(Win1 == true)
        {
            winMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (Win2 == true)
        {
            loseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
                  
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
      }
      
    
    }



    /*
    IEnumerator AI()
    {
        while(GameEnded == false)
        {
            foreach (Card i in currentTable.getPlayer().getHand())
            {
              i.ButtonFlip();

              yield return new WaitForSeconds(1);
              currentTable.player2Play();

            }
          
        }


    }
  */
      


}
