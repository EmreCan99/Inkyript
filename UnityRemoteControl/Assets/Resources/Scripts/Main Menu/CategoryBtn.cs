using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryBtn : MonoBehaviour
{
    
    void Start()
    {
        Button btn = GetComponent<Button>();
        if (btn == null)
        {
            Debug.Log("btn is null.");
        }

        int index = Int32.Parse(this.name.Substring(name.Length - 1));      // Get the last character of string

        btn.onClick.AddListener(delegate {btnFunction(index); });
    }

    public void btnFunction(int categoryIndex)
    {
        GameManager.Instance.NewGame(categoryIndex);
        Debug.Log(categoryIndex);
    }
}
