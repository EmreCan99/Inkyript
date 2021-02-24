using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystems 
{
    public static string SAVE_FOLDER;

    public static void Init()
    {

        // For Androis and IOS
        //SAVE_FOLDER = Application.persistentDataPath + "/Saves/";

        // for testing on windows
        SAVE_FOLDER = Application.dataPath + "/Saves/";

        // Test if save folder exists
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void SaveHistory(string saveString, string folderName)
    {
        File.AppendAllText(SAVE_FOLDER + folderName, saveString + "\n");
    }

    public static string[] LoadHistory(string folderName)
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

    public static void SaveLast(QuoteDB quote, int category)
    {
        string folderName = "LastQuote.txt";

        LastQuote lastItem = new LastQuote();

        if (File.Exists(SAVE_FOLDER + folderName))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + folderName);

            LastQuote savedLastItem = JsonUtility.FromJson<LastQuote>(saveString);

            lastItem.love = savedLastItem.love;
            lastItem.life = savedLastItem.life;
            lastItem.philosophy = savedLastItem.philosophy;
            lastItem.education = savedLastItem.education;
            lastItem.art = savedLastItem.art;

            // set category
            switch (category)
            {
                case 1:
                    lastItem.love = quote;
                    break;
                case 2:
                    lastItem.life = quote;
                    break;
                case 3:
                    lastItem.philosophy = quote;
                    break;
                case 4:
                    lastItem.education = quote;
                    break;
                case 5:
                    lastItem.inspirational = quote;
                    break;
                case 6:
                    lastItem.art = quote;
                    break;
                default:
                    break;
            }

            string json = JsonUtility.ToJson(lastItem);

            File.WriteAllText(SAVE_FOLDER + folderName, json);
        }
        else
        {
            // set category
            switch (category)
            {
                case 1:
                    lastItem.love = quote;
                    break;
                case 2:
                    lastItem.life = quote;
                    break;
                case 3:
                    lastItem.philosophy = quote;
                    break;
                case 4:
                    lastItem.education = quote;
                    break;
                case 5:
                    lastItem.inspirational = quote;
                    break;
                case 6:
                    lastItem.art = quote;
                    break;
                default:
                    break;
            }

            string json = JsonUtility.ToJson(lastItem);

            File.WriteAllText(SAVE_FOLDER + folderName, json);
        }   
    }

    public static LastQuote LoadLast()
    {
        string folderName = "LastQuote.txt";

        LastQuote lastItem = new LastQuote();
        
        if (File.Exists(SAVE_FOLDER + folderName))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + folderName);
            
            lastItem = JsonUtility.FromJson<LastQuote>(saveString);

            return lastItem;
        }
        else
        {
            Debug.LogError("returned NULL from SaveSystems/LoadLast");
            return null;
        }

        
    }
}
