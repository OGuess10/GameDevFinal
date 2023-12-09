using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    // public GameObject border; // Reference to the Border GameObject
    public GameObject levelOneImage; // Reference to the Level One Image GameObject
    public int lives = 3;

    private float delay;
    private Game g;
    private Vector3 curPos;

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
            Invoke("FollowMouse", 1); // Wait 1 second before following mouse
        }
        else if (g.beeCanMove)
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
        if (levelOneImage.GetComponent<PolygonCollider2D>().OverlapPoint(mousePosition))
        // if(!colliding)
        {
            // Set bee position to mouse position, with Z-coordinate of 0
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);
            curPos = transform.position;
        }
        else
        {
            // Don't move bee
            transform.position = transform.position;
        }
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     colliding = false;
    // }

    // void OnCollisionExit2D(Collision2D collision)
    // {
    //     colliding = true;
    // }


    // {
    //     // if(curPos.x > Camera.main.ScreenToWorldPoint(Input.mousePosition))
    //     // {
    //     //     colliding = false;
    //     // }

    //     // If bee is within the border, allow it to move
    //     if (border.GetComponent<BoxCollider2D>().OverlapPoint(curPos))
    //     {
    //         colliding = false;
    //     }
    //     else
    //     {
    //         colliding = true;
    //     }

    // }
}
