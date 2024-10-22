﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellButton : MonoBehaviour
{
    public delegate void MapDelegate();
    public static event MapDelegate UnlockLevels = delegate { };

    public GameObject cellButton;
    public GameObject cellNumber;
    public GameObject levelComplete;

    public AudioSource levelCompleteAudio;
    public AudioSource cellPopAudio;

    public string row;
    public int column;
    int level = int.Parse(HandleTextFile.lvlName);

    // Start is called before the first frame update
    void Start()
    {
        DisplayCells(row, column);
    }

    void DisplayCells(string cellRow, int cellColumn)
    {
        string cell = GetEmptyCell(cellRow, cellColumn);

        if (cell == "0")
        {
            cellNumber.GetComponent<Text>().text = cell;
            cellNumber.SetActive(false);
            ChangeColor(cell);
        }

        else
        {
            LevelSetUp.cellsCompleted++;
            cellNumber.GetComponent<Text>().text = cell;
            cellNumber.GetComponent<Text>().color = new Color(0, 0.203f, 0.450f, 0.5f);
            ChangeColor(cell);
            cellButton.GetComponent<Button>().interactable = false;
        }
    }

    public void ChangeCell()
    {
        string cellValue = cellNumber.GetComponent<Text>().text;
        int gridSize = int.Parse(HandleTextFile.size);

        cellPopAudio.Play();
        if (Hints.hintsOn == true)
        {
            string value = GetSolvedCell(row, column);
            cellNumber.GetComponent<Text>().text = value;
            cellNumber.GetComponent<Text>().color = new Color(0, 0.203f, 0.450f, 0.5f);
            cellNumber.SetActive(true);
            ChangeColor(value);
            cellButton.GetComponent<Button>().interactable = false;
            Hints.hintsOn = false;
            Hints.hints = Hints.hints - 1;
            GameObject.Find("HintNumber").GetComponent<Text>().text = Hints.hints.ToString();

            if (cellValue != value)
            {
                LevelSetUp.cellsCompleted++;
            }

            if (Hints.hints == 0)
            {
                GameObject.Find("HintsButton").GetComponent<Button>().interactable = false;
            }
        }

        else
        {
            switch (cellValue)
            {
                case "0":
                    cellNumber.GetComponent<Text>().text = "1";
                    cellNumber.SetActive(true);
                    ChangeColor("1");
                    break;
                case "1":
                    cellNumber.GetComponent<Text>().text = "2";
                    ChangeColor("2");
                    break;
                case "2":
                    cellNumber.GetComponent<Text>().text = "3";
                    ChangeColor("3");
                    break;
                case "3":
                    cellNumber.GetComponent<Text>().text = "4";
                    ChangeColor("4");
                    break;
                case "4":
                    if (HandleTextFile.size == "4")
                    {
                        cellNumber.GetComponent<Text>().text = "0";
                        cellNumber.SetActive(false);
                        ChangeColor("0");
                    }
                    else
                    {
                        cellNumber.GetComponent<Text>().text = "5";
                        ChangeColor("5");
                    }
                    break;
                case "5":
                    if (HandleTextFile.size == "5")
                    {
                        cellNumber.GetComponent<Text>().text = "0";
                        cellNumber.SetActive(false);
                        ChangeColor("0");
                    }
                    else
                    {
                        cellNumber.GetComponent<Text>().text = "6";
                        ChangeColor("6");
                    }
                    break;
                case "6":
                    cellNumber.GetComponent<Text>().text = "0";
                    cellNumber.SetActive(false);
                    ChangeColor("0");
                    break;
                default:
                    break;
            }

            if (cellValue == GetSolvedCell(row, column))
            {
                LevelSetUp.cellsCompleted--;

            }

            else if (cellNumber.GetComponent<Text>().text == GetSolvedCell(row, column))
            {
                 LevelSetUp.cellsCompleted++;
            }
        }

        if (LevelSetUp.cellsCompleted == (gridSize*gridSize))
        {
            if (level == 100)
            {
                levelComplete.SetActive(true);
                levelCompleteAudio.Play();
                Hints.hints = Hints.hints + 2;
            }

            else
            {
                Map.mapUnlocked[level - 1] = "2";
                UnlockLevels();
                //Map.SaveMap();
                levelComplete.SetActive(true);
                levelCompleteAudio.Play();
                LevelSetUp.cellsCompleted = 0;
                Hints.hints = Hints.hints + 2;
            }
        }

        if (HandleTextFile.lvlName == "102" && LevelSetUp.cellsCompleted == 8)
        {
            levelComplete.SetActive(true);
            levelCompleteAudio.Play();
        }
    }

    // This is taken from Unity Documentation ColorBlock.normalColor
    // https://docs.unity3d.com/2019.1/Documentation/ScriptReference/UI.ColorBlock-normalColor.html
    void ParsingColor(float r, float g, float b)
    {
        Button button = cellButton.GetComponent<Button>();
        ColorBlock cb = button.colors;
        cb.normalColor = new Color(r, g, b);
        cb.highlightedColor = new Color(r, g, b);
        cb.pressedColor = new Color(r, g, b);
        cb.disabledColor = new Color(r, g, b);
        button.colors = cb;
    }

    // Translated from RGB Hex to RGB Normalised decimal with Instalabls Color Calculator
    // http://doc.instantreality.org/tools/color_calculator/
    void ChangeColor(string value)
    {
        switch (value)
        {
            case "0":
                ParsingColor(0, 0.203f, 0.450f); // Background colour
                break;
            case "1":
                ParsingColor(0.141f, 0.823f, 0.8f); // Light blue
                break;
            case "2":
                ParsingColor(1, 0.431f, 0.509f); // Pink
                break;
            case "3":
                ParsingColor(0.980f, 0.509f, 0.254f); // Orange
                break;
            case "4":
                ParsingColor(0.439f, 0.188f, 0.631f); // Purple
                break;
            case "5":
                ParsingColor(0.552f, 0.776f, 0.247f); // Green
                break;
            case "6":
                ParsingColor(0.803f, 0, 0.513f); // Hot pink
                break;
        }
    }

    string GetEmptyCell (string cellRow, int cellColumn)
    {
        string cellValue = "";

        switch (cellRow)
        {
            case "first":
                cellValue = HandleTextFile.first[cellColumn - 1];
                break;
            case "second":
                cellValue = HandleTextFile.second[cellColumn - 1];
                break;
            case "third":
                cellValue = HandleTextFile.third[cellColumn - 1];
                break;
            case "fourth":
                cellValue = HandleTextFile.fourth[cellColumn - 1];
                break;
            case "fifth":
                cellValue = HandleTextFile.fifth[cellColumn - 1];
                break;
            case "sixth":
                cellValue = HandleTextFile.sixth[cellColumn - 1];
                break;
            default:
                break;
        }
        return cellValue;
    }

    string GetSolvedCell(string cellRow, int cellColumn)
    {
        string cellValue = "";

        switch (cellRow)
        {
            case "first":
                cellValue = HandleTextFile.solvedFirst[cellColumn - 1];
                break;
            case "second":
                cellValue = HandleTextFile.solvedSecond[cellColumn - 1];
                break;
            case "third":
                cellValue = HandleTextFile.solvedThird[cellColumn - 1];
                break;
            case "fourth":
                cellValue = HandleTextFile.solvedFourth[cellColumn - 1];
                break;
            case "fifth":
                cellValue = HandleTextFile.solvedFifth[cellColumn - 1];
                break;
            case "sixth":
                cellValue = HandleTextFile.solvedSixth[cellColumn - 1];
                break;
            default:
                break;
        }
        return cellValue;
    }
}
