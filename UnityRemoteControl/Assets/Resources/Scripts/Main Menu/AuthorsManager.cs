using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthorsManager : MonoBehaviour
{

    private void Start()
    {
        Camera _mainCamera = Camera.main;
        _mainCamera.GetComponent<Camera>().backgroundColor = new Color(247f / 255f, 247f / 255f, 247f / 255f);
    }

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
