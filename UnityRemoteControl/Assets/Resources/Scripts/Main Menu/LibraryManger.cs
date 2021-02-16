using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LibraryManger : MonoBehaviour
{
    
    void Update()
    {

        // Back button
        #region Android

        // Make sure user is on Android platform
        if (Application.platform == RuntimePlatform.Android)
        {

            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Load main menu
                SceneManager.LoadScene(1);
            }
            #endregion
        }

    }
}
