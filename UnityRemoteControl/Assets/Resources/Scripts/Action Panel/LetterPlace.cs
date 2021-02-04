using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LetterPlace : MonoBehaviour, IDropHandler
{
    Vector3 defPosition;

    private void Start()
    {
        defPosition = transform.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<ActLetter>().droppedOnSlot = true;
            eventData.pointerDrag.transform.position = defPosition;

            Debug.Log("Correct letter: " + gameObject.name + ", " + "Dropped letter: " + eventData.pointerDrag.name);
        }
    }
}
