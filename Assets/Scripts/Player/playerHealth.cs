using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    [SerializeField]private float health;
    [SerializeField]private float maxHealth;
    public Image healthbar;
    private Player player;
    private Level1Manager level1Manager;
    public GameObject DeathScreen;

    // Start is called before the first frame update
    private void Start()
    {
        maxHealth = health;
    }

    public void update()
    {
        healthbar.fillAmount = Mathf.Clamp(health/maxHealth, 0, 1);
    }
     public void takeDamage(string damageType)
    {   
        if(health <= 0){
            DeathScreen.SetActive(true);
        }
        else if (damageType == "Melee")
        {
            health -= 25;
            healthbar.fillAmount -= 0.25f;
        }
        else if (damageType == "Bullet")
        {
            health -= 10;
            healthbar.fillAmount -= 0.1f;
        }
    }
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

    
}
