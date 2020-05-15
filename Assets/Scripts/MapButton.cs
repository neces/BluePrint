using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{

    public GameObject levelButton;
    public GameObject levelText;
    public GameObject levelLocked;
    public GameObject levelSolved;

    public int levelName;

    void Start()
    {
        DisplayText();
    }

    public void DisplayText()
    {
        var status = Map.mapUnlocked[levelName - 1];

        if (status == "0") // Level is locked
        {
            levelText.GetComponent<Text>().text = " ";
            levelLocked.SetActive(true);
            levelSolved.SetActive(false);
            levelButton.GetComponent<Button>().interactable = false;
        }

        else if (status == "1") // Level is unlocked
        {
            levelText.GetComponent<Text>().text = levelName.ToString();
            levelLocked.SetActive(false);
            levelSolved.SetActive(false);
            levelButton.GetComponent<Button>().interactable = true;
        }

        else if (status == "2") // Level is completed
        {
            levelText.GetComponent<Text>().text = " ";
            levelLocked.SetActive(false);
            levelSolved.SetActive(true);
            levelButton.GetComponent<Button>().interactable = false;
        }
    }
}
