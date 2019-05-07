using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
   // public float restartDelay = 1f;
    
    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            var gameOver = FindObjectOfType<GameOverScript>();
            gameOver.ShowButtons();
            Debug.Log("Game over");
        }
    }


    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
