using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class QuotesPanel : MonoBehaviour
{

    PreProcess quotes;

    [SerializeField]
    private GameObject _characterPrefab, _wordPrefab, _rowPrefab;
    public GameObject ActPanel, BubblePanel;

    public List<GameObject> wordList = new List<GameObject>();
    public List<String> wordStringList = new List<String>();    //to send actPanel
    ActPanel actPanel;
    BublePanel _bubblePanel;

    // GameObject features
    private int 
        _characterWidth = 50,
        _characterHeight = 50,
        _spaceWidth = 25,
        _letterSpacing = 10;

    float containerWidth; 
    int rowWidthCounter = 0;

    // Booleans
    bool newRow = false;
    [SerializeField]
    bool isShuffle = false;

    void Start()
    {
        actPanel = ActPanel.GetComponent<ActPanel>();
        if (actPanel == null)
        {
            Debug.LogError("actPanel is NULL.");
        }

        _bubblePanel = BubblePanel.GetComponent<BublePanel>();
        if (_bubblePanel == null)
        {
            Debug.LogError("_bubblePnale is NULL.");
        }
    }

    public void Initiate(QuoteDB quote)
    {
        ProcessQuote(quote);
    }


    private void ProcessQuote(QuoteDB quote) 
    {   
        // Spawn the first Row
        GameObject row = Instantiate(_rowPrefab, transform);
        row.GetComponent<HorizontalLayoutGroup>().spacing = _spaceWidth;
        
        char[] charsToTrim = { ',', '.', ' ' };
        
        string str = quote.quote.ToUpper();
        Debug.Log(str);

        string[] words = str.Split();


        // word loop
        foreach(string i in words)
        {
            string word = i.TrimEnd(charsToTrim);

            rowWidthCounter += word.Length;
            
            float rowWidth = ((rowWidthCounter * _characterWidth) + ((rowWidthCounter - 1) * _letterSpacing));
            containerWidth = this.GetComponent<RectTransform>().rect.width;


            if (rowWidth >= containerWidth * 7/8)
            {
                // Spawn new Row
                row = Instantiate(_rowPrefab, transform);

                // Set spacing
                row.GetComponent<HorizontalLayoutGroup>().spacing = _spaceWidth;

                rowWidthCounter = 0;    // Reset the counter
            }

            wordStringList.Add(word);

            Populate(word, row);
        }

    }

    private void Populate(string word, GameObject row)
    {

        // Spawn Word
        GameObject wordUI = Instantiate(_wordPrefab, row.transform);
        wordUI.name = word;     // Set label with correct word

        wordList.Add(wordUI);   // Add the word to a List

        //Set button fuction
        wordUI.GetComponent<Button>().onClick.AddListener(delegate { InitialActPanel(wordList.IndexOf(wordUI)); });

        //Set spacing(again)
        wordUI.GetComponent<HorizontalLayoutGroup>().spacing = _letterSpacing;

        // Randomize letters
        if (isShuffle)
        {
            word = ShuffleWord(word);
        }

        //Spawn letters loop
        foreach (char i in word)
        {

            GameObject character = Instantiate(_characterPrefab, wordUI.transform);
            character.name = i.ToString(); // Set label of letter

            // Set Text
            Text characterText = character.GetComponent<Text>();
            if (characterText != null)
            {
                characterText.fontSize = _characterWidth;
                characterText.text = i.ToString();
            }
        }
    }

    public void InitialActPanel(int index)
    {
        if (ActPanel.GetComponent<ActPanel>().isPreviewsCreated == false)
        {
            _bubblePanel.OpenBubblePanel(index);
        }
        else
        {
            OpenActPanel(index);
            _bubblePanel.OpenOnlyBubblePanel();
            _bubblePanel.CloseMainContainer(false);     // !false
        }
    }

    public void OpenActPanel(int index)
    {
        actPanel.initiateAct(wordStringList);       // create act panel

        Debug.Log("Button clicked");
        
        ActPanel.SetActive(true);

        actPanel.ActivatePreview(index);
    }

    string ShuffleWord(string word)
    {
        char[] array = word.ToCharArray();
        System.Random rng = new System.Random();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            var value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
        return new string(array);
    }
}
