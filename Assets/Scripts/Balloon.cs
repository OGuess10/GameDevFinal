using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    void Update()
    {
        // Check if mouse collides with Balloon's collider
        if (GetComponent<CircleCollider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            // Kill the balloon
            Destroy(gameObject);
        }
    }
}
