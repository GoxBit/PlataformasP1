using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool gameIsPaused = false;
    
    [SerializeField] private GameObject pauseMenu = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            PauseGame();
            gameIsPaused = !gameIsPaused;
        }        
    }

    private void PauseGame()
    {
        if (!gameIsPaused)
        {
            Time.timeScale = 1.0f;
        }
        else 
        {   
            Time.timeScale = 0f;
        }

        pauseMenu.SetActive(gameIsPaused);

    }
}
