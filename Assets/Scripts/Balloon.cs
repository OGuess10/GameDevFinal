using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    private Game g;

    void Start()
    {
        g = Game.GetGame();
    }

    void Update()
    {
        if(!g.GetRespawn())
        {
            // Check if mouse collides with Balloon's collider
            if (GetComponent<CircleCollider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                // Kill the balloon
                Destroy(gameObject);

                // Add points
                g.AddPoint();
            }
        }
    }
}
