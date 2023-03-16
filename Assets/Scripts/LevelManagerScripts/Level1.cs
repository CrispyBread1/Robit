using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    // public GameObject DeathScreen;

    public void start()
    {
        // DeathScreen = GetComponent<DeathScreen>();
        // Debug.Log("I am level1Manager started");
        // DeathScreen.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // gameOverScreen = new GameObject();
        // DeathScreen.SetActive(true);

    }

    

}
