using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSetUp : MonoBehaviour
{
    public GameObject level_name;
    public GameObject grid_size;
    public GameObject difficulty;

    public GameObject hints_count;
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
        string name = "BluePrint " + HandleTextFile.lvl_name;
        level_name.GetComponent<Text>().text = name;
    }

    public void DisplayGridSize()
    {
        string grid = "Grid " + HandleTextFile.size;
        grid_size.GetComponent<Text>().text = grid;
    }

    public void DisplayDifficulty()
    {
        difficulty.GetComponent<Text>().text = HandleTextFile.diff;
    }

    public void DisplayHints()
    {
        hints_count.GetComponent<Text>().text = hints.ToString();
    }
}
