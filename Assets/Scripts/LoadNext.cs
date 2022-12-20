using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNext : MonoBehaviour
{

    int buildIndex;
    //public float transitionTime = 1f;
    //public Animator transition;

    private void Awake()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void NextScene()
    {
        //StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        SceneManager.LoadScene(buildIndex + 1);

    }
    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }

    //IEnumerator LoadLevel(int levelIndex)
    //{
    //    transition.SetTrigger("Start");
    //    yield return new WaitForSeconds(transitionTime);
    //    SceneManager.LoadScene(levelIndex);
    //}
}
