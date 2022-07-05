using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Variables
    public static bool isGameOver;
    public static int speedCount;
    public int Flowers;
    public GameObject gameUIManager;
    public AudioSource audioSource;

    void Start()
    {
        Flowers =  0;
        isGameOver = false;
    }

    //stop the game
    public void GameOver()
    {
        gameUIManager.GetComponent<GameUIManager>().GameOverMenu();
        isGameOver = true;
        audioSource.Stop();
    }
}
