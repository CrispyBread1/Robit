using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Bar : MonoBehaviour
{
    private Transform bar;
    [SerializeField]public float health = 1f;
    private Player player;
    private Level1Manager level1Manager;
    public GameObject DeathScreen;
    // private bool playerDead = false;

    // Start is called before the first frame update
    private void Start()
    {
        bar = transform.Find("Bar");
        setDeathScreen(false);
        
        // bar.localScale = new Vector3(.4f, 1f);
    }

    // Update is called once per frame
    public void setSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    public void getHit(float damage)
    {
        if ((health - damage) <= 0f){
            health = 0f;
            player.die();
        } else 
        {
            health -= damage;
        }
        bar.localScale = new Vector3(health, 1f);
    }

    public float getHealth()
    {
        return health;
    }

    public void update()
    {
        
        if(health == 0f)
        {
            setDeathScreen(true);
            // level1Manager.PlayerDied();
            // player.die();
            // level1Manager.GameOver();
        }
    }

    public void setDeathScreen(bool active)
    {
        DeathScreen.SetActive(active);
    }
}
