using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

  public void LoadLevelOne()
  {
    SceneManager.LoadScene(1);
  }

  public void LoadLevelTwo()
  {
    SceneManager.LoadScene(2);
  }

  public void LoadLevelThree()
  {
    SceneManager.LoadScene(3);
  }


}
