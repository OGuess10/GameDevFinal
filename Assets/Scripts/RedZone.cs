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

    void Awake()
    {
        g = Game.GetGame();
        if (g.GetLevel() == 3)
        {
            // Set position to (-0.7061678, 0.04, 0)
            transform.position = new Vector3(-0.7061678f, 0.04f, 0f);
            // Set rotation to (0, 0, 0)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            // Set scale to (1.5, 1.5, 1)
            transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        }
    }

    void Update()
    {
        if (g.GetLevel() == 2)
        {
            // Move RedZone object left and right repeatedly
            float distance = Mathf.PingPong(Time.time * 4f, 12f) - 5f;
            transform.position = new Vector3(distance, transform.position.y, transform.position.z);
        }
        else if (g.GetLevel() == 3)
        {
            float speed = 2f;
            float xStepSize = 6f;
            float yStepSize = 2f;

            // Calculate the current step based on the time
            int step = Mathf.FloorToInt(Time.time * speed) % 4;

            // Calculate the movement vector based on the current step
            Vector3 movement = Vector3.zero;
            switch (step)
            {
                case 0: // Move right
                    movement = Vector3.right * xStepSize;
                    break;
                case 1: // Move up
                    movement = Vector3.up * yStepSize;
                    break;
                case 2: // Move left
                    movement = Vector3.left * xStepSize;
                    break;
                case 3: // Move down
                    movement = Vector3.down * yStepSize;
                    break;
            }

            // Apply the movement
            transform.position += movement * Time.deltaTime;
        }
        else if (g.GetLevel() == 4)
        {
            // Move RedZone object up and down repeatedly
            float distance = Mathf.PingPong(Time.time * 4f, 6f) - 3.65f;
            transform.position = new Vector3(transform.position.x, distance, transform.position.z);
        }
    }
}
