using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BublePanel : MonoBehaviour
{
    Animator _animator;
    [SerializeField] QuotesPanel _quotesPanel;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void OpenBubblePanel()
    {
        bool isOpen = _animator.GetBool("isPanelOpen");
        _animator.SetBool("isPanelOpen", !isOpen);

        StartCoroutine(WaitForBubble());
    }

    IEnumerator WaitForBubble()
    {
        yield return new WaitForSeconds(.3f);

        _quotesPanel.OpenActPanel(0);
    }
}
