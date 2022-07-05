using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    //Variables
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    public Button toMenuButton;
    public GameObject gameManager;

    public AudioClip clickSound;
    public AudioSource audioSource;

    private void Update() 
    {
        UpdateScore();   
    }

    //update the number of flowers collected so far
    public void UpdateScore()
    {
        scoreText.text = "Flowers : "+gameManager.GetComponent<GameManager>().Flowers;
    }

    //restart the game
    public void RestartGame()
    {
        audioSource.PlayOneShot(clickSound);
        SceneManager.LoadScene(1);
    }

    //return to the game menu scene
    public void ToMenu()
    {
        audioSource.PlayOneShot(clickSound);
        SceneManager.LoadScene(0);
    }

    //show the gameover ui to the player
    public void GameOverMenu()
    {
        restartButton.gameObject.SetActive(true);
        toMenuButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
    }
}
