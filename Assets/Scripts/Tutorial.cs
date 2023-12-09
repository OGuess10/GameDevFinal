using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Text curText;
    public GameObject tutorialPanel;
    private int textNum = 0;

    public void NextButton()
    {
        textNum++;
        switch(textNum)
        {
            case 0:
                curText.text = "The objective of the game is to explode all the balloons with the bee while avoiding the red zones. You control the bee with your mouse.";
                break;
            case 1:
                curText.text = "You need to explode all the balloons to complete a level. You can explode them just by passing over with your bee.";
                break;
            case 2:
                curText.text = "Whenever you hit a red zone or a bomb, you will restart from the initial position. You will also lose a life.";
                break;
            case 3:
                curText.text = "Start buzzing!";
                break;
            case 4:
                tutorialPanel.SetActive(false);
                break;
        }
    }
}
