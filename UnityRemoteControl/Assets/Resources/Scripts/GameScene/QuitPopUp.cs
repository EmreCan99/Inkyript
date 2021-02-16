using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPopUp : MonoBehaviour
{

    void Start()
    {

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
                BackToMain();
            }
        }
        #endregion
    }

    public void BackToMain()
    {
            this.gameObject.SetActive(true);
    }

    public void NoBtn()
    {
        this.gameObject.SetActive(false);
    }

    public void YesBtn()
    {
        SceneManager.LoadScene(1);
    }
}
