using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    string GooglePlay_ID = "4020195";
    bool TestMode = true;

   

    void Start()
    {
        Advertisement.Initialize(GooglePlay_ID, TestMode);
    }

    public void DisplayIntersititialAd()
    {    
        Advertisement.Show();
    }
}
