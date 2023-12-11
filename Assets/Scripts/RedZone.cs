using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour
{
    private Game g;

    void Start()
    {
        g = Game.GetGame();
    }
    void Update()
    {
        // if(!g.GetRespawn())
        // {
            // Get the mouse position in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Check if mouse collides with Border's collider
            if (GetComponent<BoxCollider2D>().OverlapPoint(mousePosition))
            {
                // Kill the bee
                g.KillBee();
            }
        // }
    }
}
