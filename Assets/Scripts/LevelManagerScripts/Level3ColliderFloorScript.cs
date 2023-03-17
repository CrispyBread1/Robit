using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This code chages all 2DColliders to the tag of "Floor"
public class Level3ColliderFloorScript : MonoBehaviour
{
    public string targetTag = "Floor";

    private void Start()
    {
        BoxCollider2D[] boxColliders = FindObjectsOfType<BoxCollider2D>();

        foreach (BoxCollider2D boxCollider in boxColliders)
        {
            boxCollider.gameObject.tag = targetTag;
        }
    }
}

