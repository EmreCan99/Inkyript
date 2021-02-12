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

    public void NewGame()
    {
        SceneManager.LoadScene(2);
    }
}
