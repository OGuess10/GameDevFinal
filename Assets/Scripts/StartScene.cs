using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public Text lastLevelText;
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Level"))
        {
            lastLevelText.text = "Last Level Played: " + PlayerPrefs.GetInt("Level");
        }
        else
        {
            lastLevelText.text = "This is your first time playing!";
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

}
