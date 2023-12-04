using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private static Game game;
    public Bee bee;
    public bool respawn = false;

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

    // Update is called once per frame
    void Update()
    {
        
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
}
