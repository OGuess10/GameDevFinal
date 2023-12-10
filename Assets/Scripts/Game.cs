using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Game : MonoBehaviour
{
    private static Game game;
    public Bee bee;
    public static int level;
    public bool beeCanMove = false;
    public GameObject beeStartBtn;
    public Text pointsTxt;
    public Slider pointsSlider;
    public GameObject[] livesArr;
    public bool inTutorial;
    public Text timerText;
    public bool paused;
    public GameObject pausedPanel;
    public Text levelText;

    private Timer timer;
    private int points = 0;
    private float pausedTime;
    private GameObject[] balloonsList;

    public static Game GetGame()
    {
        return game;
    }

    void Awake()
    {
        game = this;
        timer = Timer.timer;
        paused = false;
        pausedPanel.SetActive(false);
        level = bee.level;
        levelText.text = "Level " + level;
        balloonsList = GetBalloons();
        pointsSlider.maxValue = balloonsList.Length;

        if(level == 0)
        {
            inTutorial = true;
        }
        else
        {
            inTutorial = false;
        }
        beeCanMove = false;
    }

    void Update()
    {
        if(!paused)
        {
            timer.targetTime -= Time.deltaTime;
            float seconds = timer.targetTime;
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            timerText.text = time.ToString(@"mm\:ss");
        }

    }

    public void Pause()
    {
        paused = true;
        pausedPanel.SetActive(true);
    }

    public void Unpause()
    {
        paused = false;
        pausedPanel.SetActive(false);
    }

    public void KillBee()
    {
        if(inTutorial)
        {
            bee.transform.position = beeStartBtn.transform.position;
            beeCanMove = false;
            beeStartBtn.SetActive(true);
        }
        else if(bee.lives <= 0)
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

    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
        beeCanMove = true;
        inTutorial = true;
    }

    public void NextLevel()
    {
        switch(level)
        {
            case 0:
                SceneManager.LoadScene("Level_1");
                break;
            case 1:
                SceneManager.LoadScene("Level_2");
                break;
            case 2:
                SceneManager.LoadScene("Level_3");
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

        if (balloonsList.Length == 1)
        {
            return true;
        }

        return false;
    }

    // Get the current level
    public int GetLevel()
    {
        return level;
    }
}
