﻿using System.Collections;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    [SerializeField] PreProcess db;
    
    // For PreProcess
    public static bool isDbCreated
    {
        get;
        set;
    }

    [SerializeField] AdManager Ad;

    static int AdCounter = 0;

    public QuoteDB quote;
    public int category;

    public List<QuoteDB> History = new List<QuoteDB>();
    public List<QuoteDB> FavoriteDb;
    public List<QuoteDB> SpecialsHistory;
    

    LastQuote lastItem;
    
    private void Awake()
    {
        _instance = this;

        SaveSystems.Init();
        
    }
 
    #region New Game

    public void NewGame(int categoryIndex)
    {
        int random = Random.Range(1, 3);
        if (random == 1)
        {
            NewSpecialQuote();
            Debug.LogWarning("Special quote");
        }
        else
        {
            NewNormalQuote(categoryIndex);
        }

        // Load InterScene
        SceneManager.LoadScene(2);
        category = categoryIndex;
    }

    void NewNormalQuote(int categoryIndex)
    {
        LoadLastQuote();

        if (lastItem == null)
        {
            lastItem = new LastQuote(null, null, null, null, null, null);
        }

        // Random selection
        if (categoryIndex == 0)
        {
            categoryIndex = Random.Range(1, 7);
        }

        List<QuoteDB> selectedDb = new List<QuoteDB>();


        // Translate category
        switch (categoryIndex)
        {
            case 1:
                selectedDb = db.loveDb;
                break;
            case 2:
                selectedDb = db.lifeDb;
                break;
            case 3:
                selectedDb = db.philosophyDb;
                break;
            case 4:
                selectedDb = db.educationDb;
                break;
            case 5:
                selectedDb = db.inspirationalDb;
                break;
            case 6:
                selectedDb = db.artDb;
                break;
            default:
                break;
        }

        QuoteDB lastItemObj = new QuoteDB(null, null, null, null, null);
        switch (categoryIndex)
        {
            case 1:
                lastItemObj = lastItem.love;
                break;
            case 2:
                lastItemObj = lastItem.life;
                break;
            case 3:
                lastItemObj = lastItem.philosophy;
                break;
            case 4:
                lastItemObj = lastItem.education;
                break;
            case 5:
                lastItemObj = lastItem.inspirational;
                break;
            case 6:
                lastItemObj = lastItem.art;
                break;
            default:
                break;
        }

        if (lastItemObj == null)
        {
            Debug.Log("lastItemObj is NULL.");

            // get current Quote
            quote = selectedDb[0];
        }
        else
        {
            string Id = "0";
            // set ID
            switch (categoryIndex)
            {
                case 1:
                    Id = lastItem.love.id;
                    break;
                case 2:
                    Id = lastItem.life.id;
                    break;
                case 3:
                    Id = lastItem.philosophy.id;
                    break;
                case 4:
                    Id = lastItem.education.id;
                    break;
                case 5:
                    Id = lastItem.inspirational.id;
                    break;
                case 6:
                    Id = lastItem.art.id;
                    break;
                default:
                    break;
            }

            QuoteDB lastObj = new QuoteDB(null, null, null, null, null);

            foreach (var item in selectedDb)
            {
                if (item.id == Id)
                {

                    lastObj = item;
                }
            }

            // get the index of the last quote
            int index = selectedDb.IndexOf(lastObj);

            Debug.Log("index: " + index);
            Debug.Log("selected db length: " + selectedDb.Count);

            // get current Quote
            quote = selectedDb[index + 1];
        }
    }

    void NewSpecialQuote()
    {
        LoadSpecials();

        List<QuoteDB> SpecialPool = new List<QuoteDB>();

        if (SpecialsHistory == null)
        {
            Debug.LogWarning("Special history is NULL");
            SpecialPool = db.specialDb.ToList();
        }
        else
        {
            foreach (var item in db.specialDb)
            {
                foreach (var i in SpecialsHistory)
                {
                    if (item != i)
                    {
                        SpecialPool.Add(item);
                    }
                }
            } 
        }

        int index = Random.Range(0, SpecialPool.Count);

        // Get current quote
        quote = SpecialPool[index];
    }
    #endregion

    public void ShowAds()
    {
        // Show ads in every second call
        if (AdCounter % 2 == 0)
        {
            Ad.DisplayIntersititialAd();
        }
        AdCounter++;
    }

    #region Save and Load

    public void SaveHistory(QuoteDB quote)
    {
        string json = JsonUtility.ToJson(quote);

        // Save

        if (quote.category.ToString() == "Author\r" || quote.category.ToString() == "Book\r")
        {
            SaveSystems.SaveHistory(json, "Special.txt");
        }
        else
        {
            SaveSystems.SaveHistory(json, "History.txt");
        }

        // last quote
        SaveLastQuote();
    }

    public void LoadHistory()
    {
        string[] saveString = SaveSystems.LoadHistory("History.txt");
        
        if (saveString != null)
        {
            // Create History db
            foreach (var item in saveString)
            {
                History.Add(JsonUtility.FromJson<QuoteDB>(item));
            }

            for (int i = 0; i < History.Count-1; i++)
            {
                Debug.Log(History[i].quote);
            }
        }
        else
        {
            Debug.LogError("saveString is NULL");
        }
    }

    void SaveLastQuote()
    {
        SaveSystems.SaveLast(quote, category);
    }

    public void LoadLastQuote()
    {
        lastItem = SaveSystems.LoadLast();
    }

    public void SaveFavorite(QuoteDB quote)
    {
        string json = JsonUtility.ToJson(quote);

        SaveSystems.SaveHistory(json, "Favorite.txt");
    }

    public void LoadFavorite()
    {
        string[] saveString = SaveSystems.LoadHistory("Favorite.txt");

        if (saveString != null)
        {
            // Create Favorite db
            foreach (var item in saveString)
            {
                FavoriteDb.Add(JsonUtility.FromJson<QuoteDB>(item));
            }

        }
        else
        {
            FavoriteDb = null;
            Debug.LogError("saveString is NULL");
        }
    }

    void LoadSpecials()
    {
        string[] saveString = SaveSystems.LoadHistory("Special.txt");

        if (saveString != null)
        {
            // Create special history db
            foreach (var item in saveString)
            {
                SpecialsHistory.Add(JsonUtility.FromJson<QuoteDB>(item));
            }

        }
        else
        {
            SpecialsHistory = null;
            Debug.LogError("saveString is NULL");
        }
    }

    #endregion
}
