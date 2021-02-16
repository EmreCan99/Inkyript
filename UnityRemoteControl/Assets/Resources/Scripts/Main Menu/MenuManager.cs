using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Animator categoryPanelAnimator;
    [SerializeField] private GameObject _upperPanel, _mainBg, _mainCamera;

    Animator upperPanelAnimator;
    
    private void Start()
    {
        upperPanelAnimator = _upperPanel.GetComponent<Animator>();

        if (_mainCamera == null)
        {
            Debug.Log("Main camera is NULL.");
        }
        _mainCamera.GetComponent<Camera>().backgroundColor = new Color(230f / 255f, 230f / 255f, 230f / 255f);
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
        SceneManager.LoadScene(3);
    }

    public void AuthorsBtn()
    {
        SceneManager.LoadScene(4);
    }
}
