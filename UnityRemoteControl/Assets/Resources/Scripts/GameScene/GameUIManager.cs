using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    QuoteDB quote;

    void Start()
    {
        GameObject _interManager = GameObject.FindGameObjectWithTag("InterManager");
        InterManager interManager = _interManager.GetComponent<InterManager>();
        if (interManager == null)
        {
            Debug.Log("intermanager is Null");
        }
        else
        {
            quote = interManager.quote;
        }

    }

    public void SaveHistory()
    {
        GameManager.Instance.SaveHistory(quote);
    }
}
