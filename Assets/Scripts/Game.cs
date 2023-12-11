using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private static Game game;
    public Bee bee;
    public int level = 0;
    public bool beeCanMove = false;
    public GameObject beeStartBtn;
    public Text pointsTxt;
    public Slider pointsSlider;
    public GameObject[] livesArr;

    private int points = 0;

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
        if(bee.lives < 0)
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
}
