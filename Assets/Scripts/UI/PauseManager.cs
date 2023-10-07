using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool gameIsPaused = false;
    
    [SerializeField] private GameObject pauseMenu = null;
    [SerializeField] private CanvasGroup canvasPause = null;
    [SerializeField] private float animationTime = 0.5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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

    public void Animate() {
        Debug.Log("Animate");
        LeanTween.alphaCanvas(canvasPause, 1f, animationTime);
    }
}
