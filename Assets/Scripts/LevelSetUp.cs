using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSetUp : MonoBehaviour
{
    public GameObject levelName;
    public GameObject gridSize;
    public GameObject difficulty;
    public GameObject levelCompleted;

    public static int cellsCompleted;

    void Start()
    {
        DisplayLevelName();
        DisplayGridSize();
        DisplayDifficulty();
        levelCompleted.SetActive(false);
    }

    public void DisplayLevelName()
    {
        string name;
        if (HandleTextFile.lvlName == "100")
        {
            name = "BluePrint Unlimimited";
            levelName.GetComponent<Text>().text = name;
        }

        else if (HandleTextFile.lvlName == "101" || HandleTextFile.lvlName == "102")
        {
            name = "BluePrint";
            levelName.GetComponent<Text>().text = name;
        }

        else
        {
            name = "BluePrint " + HandleTextFile.lvlName;
            levelName.GetComponent<Text>().text = name;
        }
    }

    public void DisplayGridSize()
    {
        string grid = "Grid " + HandleTextFile.size;
        gridSize.GetComponent<Text>().text = grid;
    }

    public void DisplayDifficulty()
    {
        difficulty.GetComponent<Text>().text = HandleTextFile.diff;
    }

    public void BackButton()
    {
        if (HandleTextFile.lvlName == "100" || HandleTextFile.lvlName == "101" || HandleTextFile.lvlName == "101")
        {
            SceneManager.LoadScene("Menu");

        }

        else
        {
            SceneManager.LoadScene("Map");
        }
    }

    public void LevelCompletedButton()
    {
        if (HandleTextFile.lvlName == "100")
        {
            GenerateLevel.LevelGenerate();
        }

        else if (HandleTextFile.lvlName == "102")
        {
            SceneManager.LoadScene("Menu");
        }

        else
        {
            SceneManager.LoadScene("Map");
        }
    }
}
