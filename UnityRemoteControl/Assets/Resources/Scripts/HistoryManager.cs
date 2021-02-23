using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HistoryManager : MonoBehaviour
{
    List<QuoteDB> HistoryDb = new List<QuoteDB>();
    [SerializeField] GameObject _historyItem;

    void Start()
    {
        Camera.main.GetComponent<Camera>().backgroundColor = new Color(243f / 255f, 243f / 255f, 243f / 255f);
        
        HistoryDb = GameManager.Instance.History;

        Initialize();
    }

    private void Initialize()
    {
        for (int i = 0; i < HistoryDb.Count-1; i++)
        {
            // process the quote
            string processedQuote;

            if (HistoryDb[i].quote.Length > 75)
            {
                processedQuote = HistoryDb[i].quote.Substring(0, 75) + "...";
            }
            else
            {
                processedQuote = HistoryDb[i].quote;
            }


            _historyItem = GameObject.Instantiate(_historyItem, transform);

            // populate History Item
            Text quote_txt = _historyItem.transform.GetChild(0).GetComponent<Text>();
            quote_txt.text = processedQuote;

            Text author_txt = _historyItem.transform.GetChild(1).GetComponent<Text>();
            author_txt.text = HistoryDb[i].author;

        }        
    }

    public void BackBtn()
    {
        SceneManager.LoadScene(1);
    }
}
