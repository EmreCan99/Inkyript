using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Animator categoryPanelAnimator;

    public void OpenCategoryPanel()
    {
        categoryPanelAnimator.SetBool("IsCategoryOpen", true);
    }

    public void CloseCategoryPanel()
    {
        categoryPanelAnimator.SetBool("IsCategoryOpen", false);
    }

    public void RandomCategoryBtn()
    {
        GameManager.Instance.NewGame();
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
