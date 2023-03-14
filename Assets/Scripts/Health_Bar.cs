using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Bar : MonoBehaviour
{
    private Transform bar;
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
}
