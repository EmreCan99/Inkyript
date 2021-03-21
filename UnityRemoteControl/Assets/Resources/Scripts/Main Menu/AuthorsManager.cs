using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthorsManager : MonoBehaviour
{
    [SerializeField] GameObject upperPanel, Pawns;
    [SerializeField] GameObject Hint;
    Animator anim;

    public List<QuoteDB> Authorslist = new List<QuoteDB>();

    private void Start()
    {
        LoadAuthors();

        Camera _mainCamera = Camera.main;
        anim = upperPanel.GetComponent<Animator>();
        _mainCamera.GetComponent<Camera>().backgroundColor = new Color(247f / 255f, 247f / 255f, 247f / 255f);

        if (PlayerPrefs.HasKey("isTutorialAuthors") == false)
        {
            anim.SetBool("CloseUpperPanel", false);
        }
        else
        {
            Hint.SetActive(false);
        }
    }

    void Update()
    {
        
        // Back button
        #region Android

        // Make sure user is on Android platform
        if (Application.platform == RuntimePlatform.Android)
        {

            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Load main menu
                SceneManager.LoadScene(1);
            }
            #endregion
        }
    }

    public void CloseUpperPanel()
    {
        anim.SetBool("CloseUpperPanel", true);
        PlayerPrefs.SetInt("isTutorialAuthors", 0);

        StartCoroutine(DestroyAnimator());
    }

    IEnumerator DestroyAnimator()
    {
        yield return new WaitForSeconds(.6f);
        Destroy(anim);
    }

    void LoadAuthors()
    {
        string[] saveString = SaveSystems.LoadHistory("Special.txt");

        if (saveString != null)
        {
            // Create unlocked Authors db
            foreach (var item in saveString)
            {
                QuoteDB quote = JsonUtility.FromJson<QuoteDB>(item);
                if (quote.category.ToString() == "Author\r")
                {
                    Authorslist.Add(quote);
                }
            }
        }
        else
        {
            Authorslist = null;
            Debug.LogError("saveString is NULL");
        }

        UnlockAuthors();
    }

    void UnlockAuthors()
    {
        foreach (var item in Authorslist)
        {
            switch (item.author)
            {
                case "Albert Einstein":
                    Pawns.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
                    Pawns.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);
                    Debug.Log("Albert Einstein unlocked");
                    break;
                case "Victor Hugo":
                    Pawns.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
                    Pawns.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(true);
                    Debug.Log("Hugo unlocked");
                    break;
                case éC.G.Jung

                    Pawns.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
                    Pawns.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(true);
                    Debug.Log("Jung unlocked");
                    break;
                case "Stephen King":
                    Pawns.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
                    Pawns.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.SetActive(true);
                    Debug.Log("King unlocked");
                    break;
                case "sagan":
                    break;
                case "Friedrich Nietzsche":
                    Pawns.transform.GetChild(2).GetChild(1).GetChild(0).gameObject.SetActive(false);
                    Pawns.transform.GetChild(2).GetChild(1).GetChild(1).gameObject.SetActive(true);
                    Debug.Log("Niçe unlocked");
                    break;
                default:
                    break;
            }
        }
    }
}
