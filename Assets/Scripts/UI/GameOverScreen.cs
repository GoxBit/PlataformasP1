using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void Restart() {
        Debug.Log("Restart");
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
