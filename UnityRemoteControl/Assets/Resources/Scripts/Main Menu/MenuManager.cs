using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{



    [SerializeField] Animator categoryPanelAnimator;
    [SerializeField] private GameObject _upperPanel, _mainBg, _mainCamera;

    Animator upperPanelAnimator;

    [SerializeField] GameObject _savedItemPrefab, SavedContent;
    public List<QuoteDB> FavoriteDb;


    private void Start()
    {

        upperPanelAnimator = _upperPanel.GetComponent<Animator>();

        if (_mainCamera == null)
        {
            Debug.Log("Main camera is NULL.");
        }
        _mainCamera.GetComponent<Camera>().backgroundColor = new Color(230f / 255f, 230f / 255f, 230f / 255f);

        FavoriteQuotes();
    }

    void FavoriteQuotes()
    {
        GameManager.Instance.LoadFavorite();
        FavoriteDb = GameManager.Instance.FavoriteDb;

        if (FavoriteDb != null)
        {

            for (int i = 0; i < FavoriteDb.Count-1; i++)
            {
                GameObject savedİtem = Instantiate(_savedItemPrefab, SavedContent.transform);
                savedİtem.transform.GetChild(0).GetComponent<Text>().text = FavoriteDb[i].quote;

            }
        }
        else
        {
            Debug.LogError("FavoriteDb is null");
        }
    }


    public void OpenCategoryPanel()
    {
        categoryPanelAnimator.SetBool("IsCategoryOpen", true);
        upperPanelAnimator.SetBool("isUpperPanelOpen", true);

        _mainBg.SetActive(false);
    }

    public void CloseCategoryPanel()
    {
        categoryPanelAnimator.SetBool("IsCategoryOpen", false);
        upperPanelAnimator.SetBool("isUpperPanelOpen", false);

        StartCoroutine(BringMainBack());       //Wait for the transition to finish

    }

    IEnumerator BringMainBack() 
    {
        yield return new WaitForSeconds(.3f);
        _mainBg.SetActive(true);
    }


    public void LibraryBtn()
    {
        SceneManager.LoadScene(4);
    }

    public void AuthorsBtn()
    {
        SceneManager.LoadScene(5);
    }

    public void HistoryBtn()
    {
        GameManager.Instance.LoadHistory();
        SceneManager.LoadScene(6);
    }
}
