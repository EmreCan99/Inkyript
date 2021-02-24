using System.Collections;
using System.IO;
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
    [SerializeField] AdManager Ad;

    public QuoteDB quote;
    public int category;

    public List<QuoteDB> History = new List<QuoteDB>();
    

    private void Awake()
    {
        _instance = this;

        SaveSystems.Init();
    }
    

    private void Start()
    {
    }

    public void NewGame(int categoryIndex)
    {
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


        // get current Quote
        quote = selectedDb[2];


        SceneManager.LoadScene(2);
        category = categoryIndex;
    }

    public void ShowAds()
    {
            Ad.DisplayIntersititialAd();
    }

    #region Save and Load

    public void SaveHistory(QuoteDB quote)
    {
        string json = JsonUtility.ToJson(quote);

        // Save
        SaveSystems.SaveHistory(json, "History.txt");

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

    public void SaveLastQuote()
    {
        SaveSystems.SaveLast(quote, category);
    }

    #endregion
}
