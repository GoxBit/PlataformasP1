using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    private int lives;

    [SerializeField] private Transform start;
    [SerializeField] private Transform finish;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            switch (lives)
            {
                case 1: lives -= 1;
                    gameObject.SetActive(false);
                    Time.timeScale = 0;
                    //UI DE PERDISTE
                    break;
                case 2: lives -= 1;
                    break;
                case 3: lives -= 1;
                    break;
            }
        }

        if(collision.gameObject.tag == "finish")
        {
            //UI DE GANASTE
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "lethal")
        {
            gameObject.SetActive(false);
            if (lives == 1)
            {
                lives -= 1;
                transform.position = start.position;
                Time.timeScale = 0;
                //UI DE PERDISTE
            }
            else if (lives >= 2)
            {
                lives -= 1;
                transform.position = start.position;
                gameObject.SetActive(true);
            }
        }
    }
}
