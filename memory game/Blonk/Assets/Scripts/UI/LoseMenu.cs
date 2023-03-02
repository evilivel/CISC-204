using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public GameObject loseMenu;
    //public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        loseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


        public void PauseGame()
        {
            //pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            //isPaused = true;

        }

        public void RestartGame()
        {
            SceneManager.LoadScene("Game");
        }
        public void GoToMainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    

       
}
