using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPopUp : MonoBehaviour
{
    [SerializeField] BublePanel _bubblePanel;
    bool isBubbleOpen;

    void Start()
    {
        if (_bubblePanel == null)
        {
            Debug.Log("bubble panel is NULL");
        }

        isBubbleOpen = _bubblePanel.isOpen;
    }

    void Update()
    {

        //// Back button
        #region Android

        //// Make sure user is on Android platform
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

        if (isBubbleOpen)
        {
            _bubblePanel.GetComponent<Animator>().SetBool("isPanelOpen", false);
            isBubbleOpen  = false;
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }

    public void NoBtn()
    {
        this.gameObject.SetActive(false);
    }

    public void YesBtn()
    {
        SceneManager.LoadScene(0);
    }
}
