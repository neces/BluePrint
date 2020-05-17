using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class HandleTextFile : MonoBehaviour
{
    public static string lvlName;
    public static string size;
    public static string diff;

    public static string[] up;
    public static string[] down;
    public static string[] left;
    public static string[] right;

    public static string[] first;
    public static string[] second;
    public static string[] third;
    public static string[] fourth;
    public static string[] fifth;
    public static string[] sixth;

    public static string[] solvedFirst;
    public static string[] solvedSecond;
    public static string[] solvedThird;
    public static string[] solvedFourth;
    public static string[] solvedFifth;
    public static string[] solvedSixth;

    public static void ReadString(int level)
    {
        string path = "Assets/Levels/" + level + ".txt";

        // Read the text from directly from the .txt file
        StreamReader reader = new StreamReader(path);
        var fileContents = reader.ReadToEnd();
        reader.Close();

        var text = fileContents.Split("\n"[0]);

        string[] lvl = text[3].Split(","[0]);

        lvlName = lvl[0];
        size = lvl[1];
        diff = lvl[2];

        up = text[6].Split(","[0]);
        down = text[7].Split(","[0]);
        left = text[8].Split(","[0]);
        right = text[9].Split(","[0]);

        first = text[12].Split(","[0]);
        second = text[13].Split(","[0]);
        third = text[14].Split(","[0]);
        fourth = text[15].Split(","[0]);

        solvedFirst = text[20].Split(","[0]);
        solvedSecond = text[21].Split(","[0]);
        solvedThird = text[22].Split(","[0]);
        solvedFourth = text[23].Split(","[0]);

        if (size == "5")
        {
            fifth = text[16].Split(","[0]);
            solvedFifth = text[24].Split(","[0]);
        }

        else if (size == "6")
        {
            fifth = text[16].Split(","[0]);
            sixth = text[17].Split(","[0]);
            solvedFifth = text[24].Split(","[0]);
            solvedSixth = text[25].Split(","[0]);
        }
    }
}
