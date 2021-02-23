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
        quote = selectedDb[0];


        SceneManager.LoadScene(2);
        category = categoryIndex;
    }

    public void ShowAds()
    {
            Ad.DisplayIntersititialAd();
    }

    public void SaveHistory(QuoteDB quote)
    {

        string json = JsonUtility.ToJson(quote);

        // Save
        SaveSystems.Save(json);

        // Load
        string saveString = SaveSystems.Load();
        if (saveString != null)
        {
            QuoteDB savedQuote = JsonUtility.FromJson<QuoteDB>(saveString);
        }
        else
        {
            Debug.Log("saveString is NULL.");
        }

    }
}
