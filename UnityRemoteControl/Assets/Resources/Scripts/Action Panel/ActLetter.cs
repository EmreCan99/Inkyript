using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActLetter : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas _canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    
    private Vector3 defaultPosition;
    public bool droppedOnSlot = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        _canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

        defaultPosition = GetComponent<RectTransform>().anchoredPosition;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;

        droppedOnSlot = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;

        if (!droppedOnSlot)
        {
            StartCoroutine(WaitForEndOfFrame());
        }
    }

    IEnumerator WaitForEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
        GetComponent<RectTransform>().anchoredPosition = defaultPosition;
    }

}
