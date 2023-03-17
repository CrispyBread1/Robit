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

    public Animator attackAnimation;





    private void Start()
    {
        maxHealth = health;
    }

    public void update()
    {   
// this ensures the gealth bar stays between 0 - 1, if the health is less than zero is sets it to zero and if its more than one it sets it to one.
        healthbar.fillAmount = Mathf.Clamp(health/maxHealth, 0, 1);
        
    }

// player takes damage
    public void takeDamage(string damageType)
    {  
        if(health <= 0){
            die();
        }
        else if (damageType == "Melee")
        {
            health -= 25;
            healthbar.fillAmount -= 0.25f;
            isDead(health);
        }
        else if (damageType == "Bullet")
        {
            health -= 10;
            healthbar.fillAmount -= 0.1f;
            isDead(health);
        }
    }

// If the player gets hit 
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("EnemyHit"))
        {
            takeDamage("Melee");
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            takeDamage("Bullet");
        }
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
        DeathScreen.SetActive(true);
    }

    
}
