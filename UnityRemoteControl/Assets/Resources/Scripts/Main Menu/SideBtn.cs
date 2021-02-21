using System.Collections;
using System;   // used for Convert.ToInt32()
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SideBtn : MonoBehaviour
{

    public Animator animator;
    [SerializeField] GameObject bg, upperPanel, categoryPanel;

    void Start()
    {
    }

    public void MoveSidePanel()
    {
        bool isOpen = animator.GetBool("isSidePanelOpen");

        // check if it is Main menu
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (categoryPanel.GetComponent<Animator>().GetBool("IsCategoryOpen"))
            {
                // Make Category Panel invisible but still active
                categoryPanel.GetComponent<CanvasGroup>().alpha = Convert.ToInt32(isOpen);
                categoryPanel.GetComponent<CanvasGroup>().blocksRaycasts = isOpen;
            }
            else
            {
                bg.SetActive(isOpen);
                upperPanel.SetActive(isOpen);
            }

        }
       
        animator.SetBool("isSidePanelOpen", !isOpen);
    }

    private void Update()
    {

        // Back button
        #region Android

        // Make sure user is on Android platform
        if (Application.platform == RuntimePlatform.Android)
        {

            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                animator.SetBool("isSidePanelOpen", false);
            }
        }
        #endregion
    }


}
