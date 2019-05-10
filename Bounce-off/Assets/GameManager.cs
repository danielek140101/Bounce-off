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

    // public float restartDelay = 1f;

    //Win/Lose screen
    public Text FinalText;
    public Image FinalPanel;
    public Button PlayAgainButton;
    public Button QuitButton;
    public Text HighScore;
    public Button PlayerInput;



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
        FinalPanel.gameObject.SetActive(true);
        FinalText.gameObject.SetActive(true);
        HighScore.gameObject.SetActive(true);
        PlayerInput.gameObject.SetActive(true);
        FinalText.text = message;
    }
    private void HideUI()
    {
        FinalPanel.gameObject.SetActive(false);
        PlayAgainButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);
        FinalText.gameObject.SetActive(false);
        HighScore.gameObject.SetActive(false);
        PlayerInput.gameObject.SetActive(false);
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
        AudioManager.manager.Lose.Play();  
        Debug.Log("Game over");
    }

    public void Win()
    {
        if (gameHasEnded == false)
        {
            {
                gameHasEnded = true; 
                ShowUI("You Win!");
                Debug.Log("Win");
                AudioManager.manager.YouWin.Play();
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
    }
}
