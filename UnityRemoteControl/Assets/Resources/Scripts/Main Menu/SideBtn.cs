using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBtn : MonoBehaviour
{

    public Animator animator;
    [SerializeField] GameObject bg;

    void Start()
    {
        
    }

    public void MoveSidePanel()
    {

        bool isOpen = animator.GetBool("isSidePanelOpen");

        bg.SetActive(isOpen);
     
        animator.SetBool("isSidePanelOpen", !isOpen);
    }
}
