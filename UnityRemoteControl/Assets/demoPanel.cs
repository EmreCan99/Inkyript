using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoPanel : MonoBehaviour
{
    Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void OpenActPanel()
    {
        bool isOpen = _animator.GetBool("isPanelOpen");
        _animator.SetBool("isPanelOpen", !isOpen);
    }
}
