using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LetterPlace : MonoBehaviour, IDropHandler
{
    Vector3 defPosition;

    private void Start()
    {

    }

    public void OnDrop(PointerEventData eventData)
    {

        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<ActLetter>().droppedOnSlot = true;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;

            Debug.Log("Correct letter: " + gameObject.name + ", " + "Dropped letter: " + eventData.pointerDrag.name);
        }
    }
}
