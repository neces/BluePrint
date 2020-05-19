using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject rules;
    public GameObject clueHighlight1;
    public GameObject clueHighlight2;
    public GameObject cellHighlight1;
    public GameObject cellHighlight2;

    string sentence = "";
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        NextButton();
    }

    public void NextButton()
    {
        if (HandleTextFile.lvlName == "101")
        {
            switch (counter)
            {
                case 0:
                    sentence = "Blueprint is solved by placing skyscrapers of different height on the grid, following certain rules";
                    break;
                case 1:
                    sentence = "Number can only appear once in every row and column";
                    break;
                case 2:
                    sentence = "Clues indicate how many buildings would you see standing at that position, looking in the direction of the arrow";
                    clueHighlight1.SetActive(true);
                    clueHighlight2.SetActive(true);
                    break;
                case 3:
                    sentence = "Remember that taller skyscrapers positioned in front of shorter ones will hide them";
                    clueHighlight1.SetActive(false);
                    clueHighlight2.SetActive(false);
                    cellHighlight1.SetActive(true);
                    cellHighlight2.SetActive(true);
                    break;
                case 4:
                    HandleTextFile.ReadString(102);
                    SceneManager.LoadScene("Tutorial");
                    break;
            }
        }

        if (HandleTextFile.lvlName == "102")
        {
            switch (counter)
            {
                case 0:
                    sentence = "Some grids already have certain numbers uncovered to help you out";
                    break;
                case 1:
                    sentence = "Select a hint and use it on an empty cell";
                    break;
                case 2:
                    sentence = "Now follow the clues and complete this Blueprint";
                    break;
            }
        }
        rules.GetComponent<Text>().text = sentence;
        counter++;
    }
}
