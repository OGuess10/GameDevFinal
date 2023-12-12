using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.IO;

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
    public InputField input;
    public InputField id;

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
        
        if(bee == null)
        {
            paused = true;
            return;
        }
        level = bee.level;
        if(level == 0)
        {
            inTutorial = true;
            paused = true;
        }
        else
        {
            inTutorial = false;
            timer = Timer.timer;
            paused = false;
            pausedPanel.SetActive(false);
            levelText.text = "Level " + level;
            timer.lastLevel = level;
            balloonsList = GetBalloons();
            pointsSlider.maxValue = balloonsList.Length;
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
        else if(bee.lives <= 1)
        {
            GameOver();
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
        if(!inTutorial)
        {
            points++;
            pointsSlider.value = points;
            pointsTxt.text = points + " Points";
            timer.totalPoints++;
        }
    }

    public void MinusPoints()
    {
        if(!inTutorial)
        {
            points--;
            pointsSlider.value = points;
            pointsTxt.text = points + " Points";
            timer.totalPoints--;
        }
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

    public void GameOver()
    {
        SceneManager.LoadScene("EndGame");

        // Store last played level
        PlayerPrefs.SetInt("Level", timer.lastLevel);
    }

    public void Restart()
    {
        timer.targetTime = 240.0f;
        SceneManager.LoadScene("Level_1");
        timer.totalPoints = 0;
    }

    public void SaveGame()
    {
        timer = Timer.timer;
        float duration = 240.0f - timer.targetTime;
        string data = "\nPlayerID: " + id.text + "\nDate: " + System.DateTime.Now + "\nDuration: " + duration + " seconds\nComments: " + input.text;

        StreamWriter writer = new StreamWriter("PlayerData.txt", true);
        writer.WriteLine(data);
        writer.Close();
    }
}
