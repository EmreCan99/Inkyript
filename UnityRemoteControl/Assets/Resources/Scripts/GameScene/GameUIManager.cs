using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    QuoteDB quote;
    
    
   
   
    void Start()
    {
        
        

    }

    public void SaveHistory()
    {
        quote = GameManager.Instance.quote;

        GameManager.Instance.SaveHistory(quote);

        SceneManager.LoadScene(1);
    }
}
