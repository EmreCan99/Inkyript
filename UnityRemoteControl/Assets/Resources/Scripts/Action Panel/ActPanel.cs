using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject 
        _ActContainerPrefab,
        _DragLayoutGroupPrefab, 
        _DropLayoutGroupPrefab, 
        _LetterOnActPrefab, 
        _LetterPlacePrefab;

    int lastClickedIndex;   // Cache memory

    [SerializeField]
    private List<GameObject> previewsList;

    public void initiateAct(List<string> words)
    {
        foreach (string word in words)
        {
            CreatePreview(word);
        }
    }

    void CreatePreview(string word)
    {
        // spawn Container
        GameObject actContainer = Instantiate(_ActContainerPrefab, transform);
        previewsList.Add(actContainer);

        // spawn Place Layout Group
        GameObject dropLayout = Instantiate(_DropLayoutGroupPrefab, actContainer.transform);

        // spawn Letter Layout Group
        GameObject dragLayout = Instantiate(_DragLayoutGroupPrefab, actContainer.transform);

        PopulateAct(dropLayout, dragLayout, word);
    }

    void PopulateAct(GameObject dropLayout, GameObject dragLayout, string word)
    {
        foreach (char i in word)
        {
            // spawn Letter Places
            GameObject letterPlace = Instantiate(_LetterPlacePrefab, dropLayout.transform);
            letterPlace.name = i.ToString();    // Set label 

            // spawn Letter_on_act
            GameObject letterAct = Instantiate(_LetterOnActPrefab, dragLayout.transform);
            letterAct.name = i.ToString();      // Set label
            letterAct.GetComponentInChildren<Text>().text = i.ToString();
        }
    }

    public void ActivatePreview(int index)
    {
        previewsList[lastClickedIndex].SetActive(false);
        lastClickedIndex = index;
        
        previewsList[index].SetActive(true);
    }
}
