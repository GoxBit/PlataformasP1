using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeSystem : MonoBehaviour
{
    private int lifes;

    [SerializeField] private Transform start = null;
    [SerializeField] List<GameObject> hearts = new List<GameObject>();


    private const int GAME_OVER_SCENE_INDEX = 2;
    private const int WIN_SCENE_INDEX = 3;

    private void Awake()
    {
        lifes = 3;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            lifes -= 1;
            AnimateHeart(hearts[lifes]);
            if (lifes <= 0) {  
                gameObject.SetActive(false);
                Time.timeScale = 0;
                //UI DE PERDISTE
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                LoadScene(GAME_OVER_SCENE_INDEX);
            }
        }

        if(collision.gameObject.tag == "finish")
        {
            Time.timeScale = 0;
            //UI DE GANASTE
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            LoadScene(WIN_SCENE_INDEX);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "lethal")
        {
            gameObject.SetActive(false);
            if (lifes == 1)
            {
                lifes -= 1;
                AnimateHeart(hearts[lifes]);
                transform.position = start.position;
                Time.timeScale = 0;
                //UI DE PERDISTE
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                LoadScene(GAME_OVER_SCENE_INDEX);
            }
            else if (lifes >= 2)
            {
                lifes -= 1;
                AnimateHeart(hearts[lifes]);
                transform.position = start.position;
                gameObject.SetActive(true);
            }
        }
    }

    private void LoadScene(int index) { 
        SceneManager.LoadScene(index);
    }

    private void AnimateHeart(GameObject heart)
    {
        if (gameObject == null) { return; }

        var sequence = LeanTween.sequence();
        sequence.append(LeanTween.scale(heart, Vector3.one * 2.0f, 0.5f).setEasePunch());
        sequence.append(LeanTween.color(heart, Color.white, 0.5f).setEaseLinear());
        LeanTween.delayedCall(1.0f, () => heart.SetActive(false));
    }
}
