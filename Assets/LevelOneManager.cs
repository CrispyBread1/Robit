using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneManager : MonoBehaviour
{
    public GameObject DeathScreen;

    public void start()
    {
        Debug.Log("I started");
        DeathScreen.SetActive(false);
    }
    public void GameOver()
    {
        // gameOverScreen = new GameObject();
        DeathScreen.SetActive(true);

    }

}
