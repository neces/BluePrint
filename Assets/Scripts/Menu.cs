using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayStory()
    {
        SceneManager.LoadScene("Map");
        Map.initialiseMap();
    }

    public void PlayUnlimited()
    {
        GenerateLevel.LevelGenerate();
    }

    public void Settings()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
