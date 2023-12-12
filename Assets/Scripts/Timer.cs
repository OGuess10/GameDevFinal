using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float targetTime = 240.0f;
    public static Timer timer;

    void Awake()
    {
        timer = this;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
    }

    void timerEnded()
    {

    }
}
