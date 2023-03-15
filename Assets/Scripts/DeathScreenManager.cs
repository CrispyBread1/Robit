using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject deathScreenPanel;


    public void ShowDeathScreen()
    {
        deathScreenPanel.SetActive(true);
    }
}

