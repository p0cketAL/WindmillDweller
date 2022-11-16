using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    
    int buildIndex;

    private void Awake() {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(buildIndex + 1);
        }
    } 
}
