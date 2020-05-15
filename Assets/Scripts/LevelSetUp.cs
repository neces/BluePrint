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

    public GameObject hintsCount;
    public int hints = 3;


    // Start is called before the first frame update
    void Start()
    {
        DisplayLevelName();
        DisplayGridSize();
        DisplayDifficulty();
        DisplayHints();
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

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

    public void DisplayHints()
    {
        hintsCount.GetComponent<Text>().text = hints.ToString();
    }

    public void BackButton()
    {
        // get a way to set the name for the scene
        SceneManager.LoadScene(1);
        // save the positions? get all the arrays and write them to the file
    }
}
