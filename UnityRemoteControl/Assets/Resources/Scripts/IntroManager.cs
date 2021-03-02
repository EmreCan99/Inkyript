using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    Button btn;
    

    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(SkipIntro);

        StartCoroutine(WaitforIntroToFinish());
    }

    IEnumerator WaitforIntroToFinish()
    {
        yield return new WaitForSeconds(3.70f);

        SceneManager.LoadScene(1);
    }

    void SkipIntro()
    {
        SceneManager.LoadScene(1);
    }
}
