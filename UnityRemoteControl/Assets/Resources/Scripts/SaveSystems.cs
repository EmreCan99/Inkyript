using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystems 
{
    public static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";

    public static void Init()
    {
        // Test if save folder exists
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void Save(string saveString)
    {
        File.AppendAllText(SAVE_FOLDER + "save.txt", saveString + "\n");
    }

    public static string Load()
    {
        if (File.Exists(SAVE_FOLDER + "s/Save.txt"))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + "save.txt");
            return saveString;
        }
        else
        {
            return null;
        }
    }

}
