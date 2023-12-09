using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private static Game game;
    public Bee bee;
    public bool respawn = false;
    public int level = 0;
    public bool beeCanMove = false;
    public GameObject beeStartBtn;

    public static Game GetGame()
    {
        return game;
    }

    public bool GetRespawn()
    {
        return respawn;
    }

    void SetRespawn()
    {
        respawn = false;
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
            bee.transform.position = Vector3.zero;
            respawn = true;
            Invoke("SetRespawn", 1);
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
}
