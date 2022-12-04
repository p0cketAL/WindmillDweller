using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNext : MonoBehaviour
{

    int buildIndex;

    private void Awake()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(buildIndex + 1);
    }   
            
        
    
}
