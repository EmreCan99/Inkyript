using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    QuoteDB quote;
    [SerializeField] GameObject sharePanel, specialAchPopUp;
    
   
   
    void Start()
    {
        
        

    }

    private void Update()
    {
    }

    public void SaveHistory()
    {
        quote = GameManager.Instance.quote;

        if (quote.category.ToString() == "Author\r")
        {
            SpecialAchived(quote, "Author");
        }
        else if (quote.category.ToString() == "Book\r")
        {
            SpecialAchived(quote, "Book");
        }

        GameManager.Instance.SaveHistory(quote);

        OpenSharePanel();
    }

    void OpenSharePanel()
    {
        sharePanel.SetActive(true);
        sharePanel.transform.GetChild(1).GetComponent<Text>().text = "\"" + quote.quote + "\"";
        sharePanel.transform.GetChild(2).GetComponent<Text>().text = quote.author;
        sharePanel.transform.GetChild(3).GetComponent<Text>().text = quote.book;
    }

    public void SaveFavoriteQuote()
    {
        GameManager.Instance.SaveFavorite(quote);
        Destroy(sharePanel.transform.GetChild(0).GetComponent<Button>());
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

    void SpecialAchived(QuoteDB quote, string category)
    {
        specialAchPopUp.transform.GetChild(0).GetComponent<Text>().text = "New " + category + " is unlocked";
        if (category == "Author")
        {
            specialAchPopUp.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = quote.author.ToString();
        }
        else if (category == "Book")
        {
            specialAchPopUp.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = quote.book.ToString();
        }


        specialAchPopUp.SetActive(true);
        StartCoroutine(ExitAchPopup());
    }

    IEnumerator ExitAchPopup()
    {
        yield return new WaitForSeconds(3f);

        InitExitAchPopup();
    }

    public void InitExitAchPopup()
    {
        specialAchPopUp.GetComponent<Animator>().SetBool("isExit", true);
    }
}
