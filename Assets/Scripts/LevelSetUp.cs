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
        string name = "BluePrint " + HandleTextFile.lvlName;
        levelName.GetComponent<Text>().text = name;
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
        SceneManager.LoadScene("Map");
    }

    public void LevelCompletedButton()
    {
        SceneManager.LoadScene("Map");
    }
}
