using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class HandleTextFile : MonoBehaviour
{
    public static string lvl_name;
    public static string size;
    public static string diff;

    public string[] up;
    public string[] down;
    public string[] left;
    public string[] right;

    public string[] first;
    public string[] second;
    public string[] third;
    public string[] fourth;
    public string[] fifth;
    public string[] sixth;

    public string[] solved_first;
    public string[] solved_second;
    public string[] solved_third;
    public string[] solved_fourth;
    public string[] solved_fifth;
    public string[] solved_sixth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ReadString(int level)
    {
        HandleTextFile h = new HandleTextFile();
        string path = "Assets/Levels/" + level + ".txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        var fileContents = reader.ReadToEnd();
        reader.Close();

        var text = fileContents.Split("\n"[0]);

        string[] lvl = text[3].Split(","[0]);

        lvl_name = lvl[0];
        //Debug.Log(lvl[0]);

        size = lvl[1];
        //Debug.Log(lvl[1]);

        diff = lvl[2];
        //Debug.Log(lvl[2]);

        h.up = text[6].Split(","[0]);
        h.down = text[7].Split(","[0]);
        h.left = text[8].Split(","[0]);
        h.right = text[9].Split(","[0]);

        h.first = text[12].Split(","[0]);
        h.second = text[13].Split(","[0]);
        h.third = text[14].Split(","[0]);
        h.fourth = text[15].Split(","[0]);

        h.solved_first = text[20].Split(","[0]);
        h.solved_second = text[21].Split(","[0]);
        h.solved_third = text[22].Split(","[0]);
        h.solved_fourth = text[23].Split(","[0]);

        if (size == "5")
        {
            h.fifth = text[16].Split(","[0]);
            h.solved_fifth = text[24].Split(","[0]);
        }

        else if (size == "6")
        {
            h.fifth = text[16].Split(","[0]);
            h.sixth = text[17].Split(","[0]);
            h.solved_fifth = text[24].Split(","[0]);
            h.solved_sixth = text[25].Split(","[0]);
        }
    }
}
