using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]public GameObject Death;
    [SerializeField]public GameObject DeathScreen;

    public void Restart()
    {
        // SceneManager.LoadScene(0);
    }

    public void MainMenu()
    {
        // SceneManager.LoadScene(1);
    }

    void Update()
    {
        if(Death.activeInHierarchy)
        {
            StartCoroutine("DeathScreenLoader");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public IEnumerator DeathScreenLoader()
    {
        yield return new WaitForSeconds(2);
        DeathScreen.SetActive(true);
    }
    void Start()
    {
        DeathScreen.SetActive(false);
    }

}
