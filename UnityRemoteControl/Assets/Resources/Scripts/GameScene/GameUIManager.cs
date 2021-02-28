using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    QuoteDB quote;
    [SerializeField] GameObject sharePanel;
    
   
   
    void Start()
    {
        
        

    }

    public void SaveHistory()
    {
        quote = GameManager.Instance.quote;

        GameManager.Instance.SaveHistory(quote);

        OpenSharePanel();
    }

    void OpenSharePanel()
    {
        sharePanel.SetActive(true);
        sharePanel.transform.GetChild(0).GetComponent<Text>().text = "\"" + quote.quote + "\"";
        sharePanel.transform.GetChild(1).GetComponent<Text>().text = quote.author;
        sharePanel.transform.GetChild(2).GetComponent<Text>().text = quote.book;
    }

    public void SaveFavoriteQuote()
    {
        GameManager.Instance.SaveFavorite(quote);
    }

    public void BackToMain()
    {
        GameManager.Instance.ShowAds();
        SceneManager.LoadScene(1);
    }

    public void NextGame()
    {
        GameManager.Instance.ShowAds();
        GameManager.Instance.NewGame(0);
    }
}
