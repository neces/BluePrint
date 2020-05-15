using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueButton : MonoBehaviour
{

    public GameObject clueButton;
    public GameObject clueArrow;
    public GameObject clueNumber;

    public string direction;
    public int number;

    // Start is called before the first frame update
    void Start()
    {
        DisplayClue(direction, number);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisplayClue(string clueDirection, int clueNo)
    {
        string clue = "";

        switch (clueDirection)
        {
            case "up":
                clue = HandleTextFile.up[clueNo - 1];
                break;
            case "down":
                clue = HandleTextFile.down[clueNo - 1];
                break;
            case "left":
                clue = HandleTextFile.left[clueNo - 1];
                break;
            case "right":
                clue = HandleTextFile.right[clueNo - 1];
                break;
            default:
                break;
        }

        if (clue == "0")
        {
            clueButton.SetActive(false);
        }
        else
        {
            clueNumber.GetComponent<Text>().text = clue;
        }
    }
}
