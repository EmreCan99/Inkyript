using System.Collections;
using System;   // used for Convert.ToInt32()
using System.Collections.Generic;
using UnityEngine;

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

        
        animator.SetBool("isSidePanelOpen", !isOpen);
    }


    
}
