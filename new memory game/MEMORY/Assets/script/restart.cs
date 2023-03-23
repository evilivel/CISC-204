using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    public GameObject winMenu;
    // Start is called before the first frame update
    void Start()
    {
        //winMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartGame()
    {
       SceneManager.LoadScene("Game");
    }
}
