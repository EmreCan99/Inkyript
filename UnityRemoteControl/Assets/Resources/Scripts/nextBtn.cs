using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class nextBtn : MonoBehaviour
{
    void Start()
    {
        
    }

    public void LoadInterScene()
    {
        SceneManager.LoadScene(1);

    }
}
