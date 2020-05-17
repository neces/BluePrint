using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hints : MonoBehaviour
{
    public GameObject hintsCount;
    public static int hints = 3;

    public static bool hintsOn = false;

    // Start is called before the first frame update
    void Start()
    {
        DisplayHints();
    }

    // Displays the correct number of remaining hints
    public void DisplayHints()
    {
        hintsCount.GetComponent<Text>().text = hints.ToString();
        if (hints < 1)
        {
            GameObject.Find("HintsButton").GetComponent<Button>().interactable = false;
        }
    }

    // Is used to indicate the Hint button was pressed
    public void HintsOn()
    {
        hintsOn = true;
    }
}
