using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Bar : MonoBehaviour
{
    private Transform bar;
    private float health = 1f;

    // Start is called before the first frame update
    private void Start()
    {
        bar = transform.Find("Bar");
        // bar.localScale = new Vector3(.4f, 1f);
    }

    // Update is called once per frame
    public void setSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    public void getHit(float damage)
    {
        health -= damage;
        bar.localScale = new Vector3(health, 1f);
    }

    public float getHealth()
    {
        return health;
    }
}
