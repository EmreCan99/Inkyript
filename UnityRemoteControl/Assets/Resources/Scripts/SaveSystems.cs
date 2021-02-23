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

    public static void Save(string saveString, string folderName)
    {
        File.AppendAllText(SAVE_FOLDER + folderName, saveString + "\n");
    }

    public static string[] Load(string folderName)
    {
        if (File.Exists(SAVE_FOLDER + folderName))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + folderName);

            Debug.Log("savestring is: " + saveString);

            string[] stringRows = saveString.Split(new char[] { '\n' });
            return stringRows;
        }
        else
        {   
            Debug.Log("returned NULL from SaveSystems");
            return null;
        }
    }

}
