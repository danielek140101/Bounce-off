using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public GameObject win;
    GameObject[] enemies;
    public int remainingEnemies;
    bool gameHasEnded = false;
    public bool playerIsDead = false;
    public AudioClip YouWin;
    public AudioClip Lose;

    // public float restartDelay = 1f;

    //Win/Lose screen
    public Text FinalText;
    public Image FinalPanel;
    public Button PlayAgainButton;
    public Button QuitButton;
    public AudioSource audio;


    private void Update()
    {
        CheckWin();
        CheckLose();
    }

    public void Start()
    {
        HideUI();
    }


    private void ShowUI(string message)
    {
        PlayAgainButton.gameObject.SetActive(true);
        QuitButton.gameObject.SetActive(true);
        FinalText.gameObject.SetActive(true);
        FinalPanel.gameObject.SetActive(true);
        FinalText.text = message;

        //audio.Play();
    }
    private void WinAudio()
    {
        audio.Stop();
        audio.clip = YouWin;
        audio.Play();
    }

    private void LoseAudio()
    {
        audio.Stop();
        audio.clip = Lose;
        audio.Play();
    }

    private void HideUI()
    {
        FinalPanel.gameObject.SetActive(false);
        PlayAgainButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);
        FinalText.gameObject.SetActive(false);
    }

    private void CheckLose()
    {
        if (playerIsDead && !gameHasEnded)
        {
            GameOver();
        }
    }

    private void CheckWin()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        remainingEnemies = enemies.Length;

        if (remainingEnemies == 0)
        {
            Win();
        }
    }

    public void GameOver()
    {
        gameHasEnded = true;
        ShowUI("Game Over");
        LoseAudio();
        Debug.Log("Game over");
    }

    public void Win()
    {
        if (gameHasEnded == false)
        {
            {
                gameHasEnded = true;
                ShowUI("You Win!");
                WinAudio();
                Debug.Log("Win");
            }
        }
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");


    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
        audio.Play();
    }
}
