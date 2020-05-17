using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{

    public static string[] mapUnlocked;
    static int levelsCompleted = 0;

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

    public void mapUpdate()
    {
        // when backbutton on a level clicked or level completed
        // with every level completed levelsCompleted++
        // When levelCompleted 3, 6, 9... new section opens
        // with every update also save?
        // also calls mapSave
    }

    public static void saveMap()
    {
        var writeMap = string.Join(",", mapUnlocked); ;
        File.WriteAllText("Assets/Levels/Map.txt", writeMap);
    }

    public void LevelLoad(int lvl)
    {
        HandleTextFile.ReadString(lvl);
        Debug.Log(HandleTextFile.lvlName);
        Debug.Log(HandleTextFile.size);
        Debug.Log(HandleTextFile.diff);

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
