using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{

    private Button[] buttons;

    private void Start()
    {
        if (GUI.Button(new Rect(0, 0, 80, 20), "Play again"))
        {
            SceneManager.LoadScene("Main");
        }
        if (GUI.Button(new Rect(0, 25, 80, 20), "Quit"))
        {
            SceneManager.LoadScene("MainMenu");
        }
       
    }

    void Awake()
    {
        // Get the buttons
        buttons = GetComponentsInChildren<Button>();

        // Disable them
        HideButtons();
    }

    public void HideButtons()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(false);
        }
    }

    public void ShowButtons()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(true);
        }
    }
}

    