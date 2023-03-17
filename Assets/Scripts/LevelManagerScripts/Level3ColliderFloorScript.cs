using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

