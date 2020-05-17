using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GenerateLevel : MonoBehaviour
{
    public static int levelName = 100;
    public static int gridSize = 4;
    public static string difficulty = "Medium";

    public static int[,] grid = new int[,]
    {
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 }
    };

    public static int[,] empty = new int[,]
{
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 }
};

    public static int[,] clues = new int[,]
    {
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 }
    };

    public static void LevelGenerate()
    {
        //at the end of previous game, levelName, Gridsize and difficulty are changed
        GenerateGrid(gridSize);
        CalculateClues(gridSize, difficulty);
        SaveToFile();
        SceneLoad();
    }

    public static void SceneLoad()
    {
        HandleTextFile.ReadString(100);
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

    public static void GenerateGrid(int size)
    {
        int counter = 0;
        int row = 0;
        int column = 0;
        bool duplicate = false;

        for (row = 0; row < size; row++)
        {
            for (column = 0; column < size; column++)
            {
                grid[row, column] = Random.Range(1, size + 1);

                //for loop to check rows for repeats
                for (int c = 0; c < column; c++)
                {

                    // if there is repeat go back a column and set duplicate to true
                    if (grid[row, column] == grid[row, c])
                    {
                        column--;
                        duplicate = true;
                        break;
                    }
                    duplicate = false;
                }

                // if loop to check columns for repeats
                if (duplicate == false)
                {
                    for (int r = 0; r < row; r++)
                    {
                        // if repeat then go back row
                        if (grid[row, column] == grid[r, column])
                        {
                            duplicate = true;
                            counter++;
                            break;
                        }
                    }

                    if (duplicate == true && counter <= size * size)
                    {
                        row--;
                    }

                    if (duplicate == true && counter > size * size)
                    {
                        counter = 0;
                        column = 0;
                        row = 0;
                        break;
                    }
                }
            }
        }
    }

    public static void CalculateClues(int size, string difficulty)
    {
        int direction;
        int number;
        int totalClues = 0;

        switch (difficulty)
        {
            case "Easy":
                totalClues = size * 2 + 2;
                break;
            case "Medium":
                totalClues = size * 2;
                break;
            case "Hard":
                totalClues = size * 2 - 2;
                break;
        }

        for (int i = totalClues; totalClues >= 0; totalClues--)
        {
            direction = Random.Range(0, 4);
            number = Random.Range(0, size);

            clues[direction, number] = ClueNumber(direction, number);
        }
    }

    public static int ClueNumber(int direction, int number)
    {
        int clueValue = 1;

        if (direction == 0)
        {
            for (int i = 1; i < gridSize; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (grid[j, number] > grid[i, number])
                    {
                        break;
                    }

                    if (i == j)
                    {
                        clueValue++;
                    }
                }
            }
        }

        else if (direction == 1)
        {
            for (int i = gridSize - 2; i > -1; i--)
            {
                for (int j = gridSize - 1; j >= i; j--)
                {
                    if (grid[j, number] > grid[i, number])
                    {
                        break;
                    }

                    if (i == j)
                    {
                        clueValue++;
                    }
                }

            }
        }

        else if (direction == 2)
        {
            for (int i = 1; i < gridSize; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (grid[number, j] > grid[number, i])
                    {
                        break;
                    }

                    if (i == j)
                    {
                        clueValue++;
                    }
                }

            }
        }

        else if (direction == 3)
        {
            for (int i = gridSize-2; i > -1; i--)
            {
                for (int j = gridSize-1; j >= i; j--)
                {
                    if (grid[number, j] > grid[number, i])
                    {
                        break;
                    }

                    if (i == j)
                    {
                        clueValue++;
                    }
                }

            }
        }
        return clueValue;
    }

    public static void SaveToFile()
    {
        string description = "Level Details: Unlimited\n" + "If there is no clues/filled out cells at that position set to 0.\n";
        string lineBreak = "___________\n";
        string levelDetails = levelName + "," + gridSize + "," + difficulty + "\n";

        string cluesGrid = "Clues (Up, Down, Left, Right of the grid)\n" + GetArrayString(clues);
        string emptyGrid = "Empty Grid (First to sixth row, if there are some cells already filled out)\n" + GetArrayString(empty);
        string solvedGrid = "Solved Grid(First to sixth row, if grid smaller set those columns/ rows to all 0)\n" + GetArrayString(grid);

        File.WriteAllText("Assets/Levels/100.txt", description + lineBreak + levelDetails + lineBreak + cluesGrid + lineBreak + emptyGrid + lineBreak + solvedGrid);
    }

    public static string GetArrayString(int[,] arr)
    {
        int rowLength = arr.GetLength(0);
        int colLength = arr.GetLength(1);
        string arrayString = "";

        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                arrayString += string.Format("{0},", arr[i, j]);
            }
            arrayString += System.Environment.NewLine;
        }
        Debug.Log(arrayString);
        return arrayString;
    }
}