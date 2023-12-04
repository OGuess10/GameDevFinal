using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public GameObject border; // Reference to the Border GameObject
    public int lives = 3;
    
    private float delay;
    private Game g;

    // Start is called before the first frame update
    void Start()
    {
        g = Game.GetGame();
    }

    // Update is called once per frame
    void Update()
    {

        if(g.GetRespawn())
        {
            Invoke("FollowMouse", 1);
        }
        else
        {
            // Follow mouse
            FollowMouse();
        }
    }

    // Follow mouse
    void FollowMouse()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Check if mouse collides with Border's collider
        if (border.GetComponent<BoxCollider2D>().OverlapPoint(mousePosition))
        {
            // Set bee position to mouse position, with Z-coordinate of 0
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);
        }
    }
}
