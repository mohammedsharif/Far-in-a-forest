using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public AudioClip clickSound;
    public AudioSource audioSource;
    //start a new game
    public void StartNew()
    {
        audioSource.PlayOneShot(clickSound);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        audioSource.PlayOneShot(clickSound);
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }
}
