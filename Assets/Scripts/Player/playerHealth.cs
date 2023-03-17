using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    [SerializeField]private float health;
    [SerializeField]private float maxHealth;
    public GameObject DeathScreen;
    public Image healthbar;

    private Player player;

    public bool isAttacking;

    





    private void Start()
    {
        maxHealth = health;
    }

    public void update()
    {   
// this ensures the health bar stays between 0 - 1, if the health is less than zero is sets it to zero and if its more than one it sets it to one.
        healthbar.fillAmount = Mathf.Clamp(health/maxHealth, 0, 1);
        
    }

// player takes damage
    public void takeDamage(float takeDamage)
    {  
        Debug.Log("i am in takeDagame functuion in playerHealth");
        if(health <= 0){
            die();
        }
        health -= takeDamage;
        healthbar.fillAmount -= (takeDamage / 100);
        isDead(health);
    }


    private void IsAttacking(){
        isAttacking = true;
    }

// passing through the curent player health to check if dead
    private void isDead(float health)
    {
        if (health <= 0){
            die();
        }
    }

// player has died runs the deathscreen
    private void die()
    {
        Destroy(gameObject);
        DeathScreen.SetActive(true);
    }

    
}
