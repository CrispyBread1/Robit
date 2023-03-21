using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRockMonsterCreator : MonoBehaviour
{


    public GameObject rock = null;

    public GameObject bullet;
    public Transform bulletPosition;
    
    
    
    public Animator animator;


    
    public void fire()
    {
        animator.SetTrigger("Fire");
    }
    

    private void Shoot(){
// this creats a new bullet object (bullet) when it shoots
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
    }



    
    
}
