using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private static Game game;
    public Bee bee;
    public static int level = 0;
    public bool beeCanMove = false;
    public GameObject beeStartBtn;
    public Text pointsTxt;
    public Slider pointsSlider;
    public GameObject[] livesArr;

    private int points = 0;
    private GameObject[] balloonsList;

    public static Game GetGame()
    {
        return game;
    }

    void Awake()
    {
        game = this;
    }

    public void KillBee()
    {
        if(bee.lives <= 0)
        {
            Destroy(bee);
        } else
        {
            bee.lives--;
            livesArr[bee.lives].SetActive(false);
            bee.transform.position = beeStartBtn.transform.position;
            beeCanMove = false;
            beeStartBtn.SetActive(true);
            // Invoke("SetRespawn", 1);
        }
    }

    public void NextLevel()
    {
        level++;
        switch(level)
        {
            case 1:
                SceneManager.LoadScene("Level_1");
                beeCanMove = false;
                break;
            case 2:
                // SceneManager.LoadScene("Level_2");
                beeCanMove = false;
                Debug.Log("Loaded Level 2");
                break;
            case 3:
                // SceneManager.LoadScene("Level_2");
                beeCanMove = false;
                Debug.Log("Loaded Level 3");
                break;
        }
    }

    public void StartBee()
    {
        beeCanMove = true;
        beeStartBtn.SetActive(false);
    }

    public void AddPoint()
    {
        points++;
        pointsSlider.value = points;
        pointsTxt.text = points + " Points";
    }

    // Get a list of all the balloons in the scene
    public GameObject[] GetBalloons()
    {
        return GameObject.FindGameObjectsWithTag("Balloon");
    }

    // Check if all balloons are gone
    public bool AllBalloonsGone()
    {
        balloonsList = GetBalloons();
        Debug.Log("Length: " + balloonsList.Length);
        Debug.Log("Level: " + level);

        switch (level)
        {
            case 1:
                if (balloonsList.Length == 1)
                {
                    Debug.Log("Level 1 Complete");
                    return true;
                }
                break;
            case 2:
                if (balloonsList.Length == 2)
                {
                    Debug.Log("Level 2 Complete");
                    return true;
                }
                break;
            case 3:
                if (balloonsList.Length == 3)
                {
                    Debug.Log("Level 3 Complete");
                    return true;
                }
                break;
        }
        return false;
    }
}
