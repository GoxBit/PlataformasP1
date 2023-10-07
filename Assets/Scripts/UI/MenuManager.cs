using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _panelOptions = null;

    public void Play(int sceneNumber) {
        SceneManager.LoadScene(sceneNumber);
    }

    public void Exit() {
        Application.Quit();
        UnityEngine.Debug.Log("Exit");
    }

    public void Options() { 
        _panelOptions.SetActive(true);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { 
            _panelOptions.SetActive(false);
        }
    }
}
