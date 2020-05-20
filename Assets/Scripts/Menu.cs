using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject story;
    public GameObject unlimited;
    public GameObject tutorial;

    public GameObject storyTitle;
    public GameObject unlimitedTitle;

    void Start()
    {
        if (!File.Exists("Assets/Levels/Map.txt"))
        {
            story.GetComponent<Button>().interactable = false;
            unlimited.GetComponent<Button>().interactable = false;
            storyTitle.GetComponent<Text>().color = new Color(0.701f, 0.701f, 0.701f, 1);
            unlimitedTitle.GetComponent<Text>().color = new Color(0.701f, 0.701f, 0.701f, 1);
        }
        Map.InitialiseMap();
    }

    public void PlayStory()
    {
        SceneManager.LoadScene("Map");
    }

    public void PlayUnlimited()
    {
        GenerateLevel.LevelGenerate();
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene("Tutorial");
        HandleTextFile.ReadString(101);
    }
}
