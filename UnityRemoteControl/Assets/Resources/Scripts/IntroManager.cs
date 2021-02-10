using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(WaitforIntroToFinish());
    }

    IEnumerator WaitforIntroToFinish()
    {
        yield return new WaitForSeconds(3.70f);

        SceneManager.LoadScene(0);
    }
}
