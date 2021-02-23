using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterManager : MonoBehaviour
{
    [SerializeField] GameObject quotesPanel;

    public QuoteDB quote;
    int categoryIndex;
    Color categoryColor;

    void Awake()
    {
        Debug.Log("Awake");

        quote = GameManager.Instance.quote;
        categoryIndex = GameManager.Instance.category;

        // Set category colors
        switch (categoryIndex)
        {
            case 0:
                categoryColor = new Color(207f / 255f, 230f / 255f, 161f / 255f); // Green
                break;
            case 1:
                categoryColor = new Color(250f / 255f, 184f / 255f, 175f / 255f); // Red
                break;
            case 2:
                categoryColor = new Color(164f / 255f, 227f / 255f, 213f / 255f); // Blue
                break;
            case 3:
                categoryColor = new Color(255f / 255f, 230f / 255f, 176f / 255f); // Orange
                break;
            case 4:
                categoryColor = new Color(202f / 255f, 162f / 255f, 216f / 255f); // Purple
                break;
            case 5:
                categoryColor = new Color(238f / 255f, 262f / 255f, 179f / 255f); // Yellow
                break;
            case 6:
                categoryColor = new Color(150f / 255f, 183f / 255f, 204f / 255f); // ble2
                break;
            default:
                Debug.LogError("Wrong color input");
                break;
        }



        Debug.Log(quote.quote.ToString());

        SceneManager.LoadScene(3);

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

        // set background color
        GameObject MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        if (MainCamera == null)
        {
            Debug.Log("camera is null");
        }


        MainCamera.GetComponent<Camera>().backgroundColor = categoryColor;


        // Initiate quote
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
