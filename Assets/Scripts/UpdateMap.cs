using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMap : MonoBehaviour
{
    public static int levelsCompleted = 0;

    void Start()
    {
        CellButton.UnlockLevels += UpdateUnlockedLevels;
    }

    public void readUnlockedLevels()
    {
        foreach (string state in Map.mapUnlocked)
        {
            if (state == "2")
            {
                levelsCompleted++;
            }
        }
    }

    public void UpdateUnlockedLevels()
    {
        readUnlockedLevels();

        if (levelsCompleted == 3)
        {
            Map.mapUnlocked[levelsCompleted] = "1";
            Map.mapUnlocked[levelsCompleted + 1] = "1";
            Map.mapUnlocked[levelsCompleted + 2] = "1";
        }

        else if (levelsCompleted == 6)
        {
            Map.mapUnlocked[levelsCompleted] = "1";
            Map.mapUnlocked[levelsCompleted + 1] = "1";
            Map.mapUnlocked[levelsCompleted + 2] = "1";
        }

        else if (levelsCompleted == 9)
        {
            Map.mapUnlocked[levelsCompleted] = "1";
            Map.mapUnlocked[levelsCompleted + 1] = "1";
            Map.mapUnlocked[levelsCompleted + 2] = "1";
        }

        else if (levelsCompleted == 12)
        {
            Map.mapUnlocked[levelsCompleted] = "1";
            Map.mapUnlocked[levelsCompleted + 1] = "1";
            Map.mapUnlocked[levelsCompleted + 2] = "1";
        }
        Map.SaveMap();
    }
}
