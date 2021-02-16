using System.Collections;
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
    public QuoteDB quote;
    public int category;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        GetQuote();
    }

    void GetQuote()
    {
        quote = db.quotedb[0];
    }

    public void NewGame(int categoryIndex)
    {
        SceneManager.LoadScene(1);
        category = categoryIndex;
    }
}
