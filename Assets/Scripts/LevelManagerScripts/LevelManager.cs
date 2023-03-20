using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject PauseButton;

    public bool canPause = false;

    public void start()
    {
        
    }

    public void Update()
    {
// pause menu coming up
        if(Input.GetKey(KeyCode.Escape) && canPause)
        {
            pauseGame();
            canPause = false;

        }

        if(Input.GetKey(KeyCode.Escape) && !canPause)
        {
            unPauseGame();
            canPause = true;
            
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // gameOverScreen = new GameObject();
        // DeathScreen.SetActive(true);

    }

    public void pauseGame()
    {
    
        PauseMenu.SetActive(true);  
        PauseButton.SetActive(false);
        Time.timeScale = 0;     
         
    }

    public void unPauseGame()
    {
        
        PauseMenu.SetActive(false); 
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    

}