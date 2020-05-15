using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellButton : MonoBehaviour
{

    public GameObject cellButton;
    public GameObject cellNumber;

    public string row;
    public int column;

    // Start is called before the first frame update
    void Start()
    {
        DisplayCells(row, column);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DisplayCells(string cellDirection, int cellNo)
    {
        string cell = "";

        switch (cellDirection)
        {
            case "first":
                cell = HandleTextFile.first[cellNo - 1];
                break;
            case "second":
                cell = HandleTextFile.second[cellNo - 1];
                break;
            case "third":
                cell = HandleTextFile.third[cellNo - 1];
                break;
            case "fourth":
                cell = HandleTextFile.fourth[cellNo - 1];
                break;
            case "fifth":
                cell = HandleTextFile.fifth[cellNo - 1];
                break;
            case "sixth":
                cell = HandleTextFile.sixth[cellNo - 1];
                break;
            default:
                break;
        }

        if (cell == "0")
        {
            cellNumber.GetComponent<Text>().text = cell;
            cellNumber.SetActive(false);
            ParsingColor(0, 0.203f, 0.450f);

        }
        else
        {
            cellNumber.GetComponent<Text>().text = cell;

            switch (cell)
            {
                case "1":
                    ParsingColor(0.141f, 0.823f, 0.8f);
                    break;
                case "2":
                    ParsingColor(1, 0.431f, 0.509f);
                    break;
                case "3":
                    ParsingColor(0.980f, 0.509f, 0.254f);
                    break;
                case "4":
                    ParsingColor(0.4f, 0.176f, 0.568f);
                    break;
                case "5":
                    ParsingColor(0.552f, 0.776f, 0.247f);
                    break;
                case "6":
                    ParsingColor(0.803f, 0, 0.513f);
                    break;
            }
        }
    }

    public void ChangeCell()
    {
        string cellValue = cellNumber.GetComponent<Text>().text;

        switch (cellValue)
        {
            case "0":
                ParsingColor(0.141f, 0.823f, 0.8f); // Light blue
                cellNumber.GetComponent<Text>().text = "1";
                cellNumber.SetActive(true);
                break;
            case "1":
                ParsingColor(1, 0.431f, 0.509f); // Pink
                cellNumber.GetComponent<Text>().text = "2";
                break;
            case "2":
                ParsingColor(0.980f, 0.509f, 0.254f); // Orange
                cellNumber.GetComponent<Text>().text = "3";
                break;
            case "3":
                ParsingColor(0.4f, 0.176f, 0.568f); // Purple
                cellNumber.GetComponent<Text>().text = "4";
                break;
            case "4":
                if (HandleTextFile.size == "4")
                {
                    ParsingColor(0, 0.203f, 0.450f); // Background colour
                    cellNumber.GetComponent<Text>().text = "0";
                    cellNumber.SetActive(false);
                }
                else
                {
                    ParsingColor(0.552f, 0.776f, 0.247f); // Green
                    cellNumber.GetComponent<Text>().text = "5";
                }
                break;
            case "5":
                if (HandleTextFile.size == "5")
                {
                    ParsingColor(0, 0.203f, 0.450f); // Background colour
                    cellNumber.GetComponent<Text>().text = "0";
                    cellNumber.SetActive(false);
                }
                else
                {
                    ParsingColor(0.803f, 0, 0.513f); // Hot pink
                    cellNumber.GetComponent<Text>().text = "6";
                }
                break;
            case "6":
                ParsingColor(0, 0.203f, 0.450f); // Background colour
                cellNumber.GetComponent<Text>().text = "0";
                cellNumber.SetActive(false);
                break;
            default:
                break;
        }

        // if hints on, reveal
        // if zero is back -1 na solved pieces, when all it hits the number calculates if correct

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
        button.colors = cb;
    }
}
