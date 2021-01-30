using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void NewGameBtn()
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
