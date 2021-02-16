using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterManager : MonoBehaviour
{
    [SerializeField] GameObject quotesPanel;

    QuoteDB quote;
    void Awake()
    {
        Debug.Log("Awake");

        quote = GameManager.Instance.quote;

        Debug.Log(quote.quote.ToString());

        SceneManager.LoadScene(2);
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // called first
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        quotesPanel = GameObject.FindGameObjectWithTag("QuotesPanel");
        if (quotesPanel != null)
        {
            quotesPanel.GetComponent<QuotesPanel>().Initiate(quote);
        }
    }

    void Start()
    {

    }
}
