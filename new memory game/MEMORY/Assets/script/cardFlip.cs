using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardFlip : MonoBehaviour
{
    public GameObject cardFront;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //remove card back if card is removed
        if (cardFront == null)
        {
            GameObject help = gameObject;
            Destroy(help);
        }
        

        
    }

    void OnMouseDown()
    {
        
        //iTween.RotateTo(gameObject, iTween.Hash("y", 90, "time", .5f, "easetype", iTween.EaseType.easeInOutQuad));
        cardFront.SetActive(true);
        //iTween.RotateTo(gameObject, iTween.Hash("y", 180, "time", .5f, "easetype", iTween.EaseType.easeInOutQuad));

        Debug.Log("clicked");

    }


    

}
