using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BublePanel : MonoBehaviour
{
    Animator _animator;
    [SerializeField] QuotesPanel _quotesPanel; 
    [SerializeField] GameObject _mainContainer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void OpenBubblePanel(int index)
    {
        bool isOpen = _animator.GetBool("isPanelOpen");
        _animator.SetBool("isPanelOpen", !isOpen);

        CloseMainContainer(isOpen);

        StartCoroutine(WaitForBubble(index));
    }

    public void OpenOnlyBubblePanel()
    {
        _animator.SetBool("isPanelOpen", true);
    }

    public void CloseMainContainer(bool isOpen)
    {
        _mainContainer.SetActive(!isOpen);
    }

    IEnumerator WaitForBubble(int index = 0)
    {
        yield return new WaitForSeconds(.3f);

        _quotesPanel.OpenActPanel(index);
    }
}
