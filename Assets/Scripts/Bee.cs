using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public GameObject border;
    public int lives = 5;
    public int level;

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
        if (g.beeCanMove)
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

        // Determine current level
        switch (Game.level)
        {
            case 0:
                // Check if mouse collides with Border's collider
                if (border.GetComponent<BoxCollider2D>().OverlapPoint(mousePosition))
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
                break;
            case 1:
            case 2:
                // Check if mouse collides with Border's collider
                if (border.GetComponent<PolygonCollider2D>().OverlapPoint(mousePosition))
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
                break;
            default:
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.gameObject.tag);
        if(collision.gameObject.tag == "Bomb")
        {
            Destroy(collision.gameObject);
            g.KillBee();
        }
        else if (collision.gameObject.tag == "RedZone")
        {
            g.KillBee();
        }
        else if(collision.gameObject.tag == "Balloon")
        {
            Destroy(collision.gameObject);
            g.AddPoint();

            if (g.AllBalloonsGone())
            {
                g.NextLevel();
            }
        }
    }
}
