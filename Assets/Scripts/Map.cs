using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{

    public static string[] mapUnlocked;
    public static int levelsCompleted = 0;

    public static void initialiseMap()
    {
        if (!File.Exists("Assets/Levels/Map.txt"))
        {
            // Using 0 for locked levels, 1 for unlocked and 2 for completed
            var writeMe = "1,1,1,0,0,0,0,0,0,0,0,0,0,0,0";
            File.WriteAllText("Assets/Levels/Map.txt", writeMe);
        }

        string path = "Assets/Levels/Map.txt";
        StreamReader reader = new StreamReader(path);
        var fileContents = reader.ReadToEnd();
        reader.Close();

        mapUnlocked = fileContents.Split(","[0]);
    }

    public static void updateMap()
    {
        // if the story here go scenes as well, otherwise put just in one if
        if (levelsCompleted == 3)
        {
            mapUnlocked[levelsCompleted] = "1";
            mapUnlocked[levelsCompleted + 1] = "1";
            mapUnlocked[levelsCompleted + 2] = "1";
        }

        else if (levelsCompleted == 6)
        {
            mapUnlocked[levelsCompleted] = "1";
            mapUnlocked[levelsCompleted + 1] = "1";
            mapUnlocked[levelsCompleted + 2] = "1";
        }

        else if (levelsCompleted == 9)
        {
            mapUnlocked[levelsCompleted] = "1";
            mapUnlocked[levelsCompleted + 1] = "1";
            mapUnlocked[levelsCompleted + 2] = "1";
        }

        else if (levelsCompleted == 12)
        {
            mapUnlocked[levelsCompleted] = "1";
            mapUnlocked[levelsCompleted + 1] = "1";
            mapUnlocked[levelsCompleted + 2] = "1";
        }
    }

    public static void saveMap()
    {
        var writeMap = string.Join(",", mapUnlocked); ;
        File.WriteAllText("Assets/Levels/Map.txt", writeMap);
    }

    public void LevelLoad(int lvl)
    {
        HandleTextFile.ReadString(lvl);

        // Depending on size of the grid this function loads a scene
        if (HandleTextFile.size == "4")
        {
            SceneManager.LoadScene("Grid 4");
        }

        else if (HandleTextFile.size == "5")
        {
            SceneManager.LoadScene("Grid 5");
        }

        else if (HandleTextFile.size == "6")
        {
            SceneManager.LoadScene("Grid 6");
        }
    }

    public void backButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
