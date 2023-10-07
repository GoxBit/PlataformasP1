using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    [SerializeField] private AudioClip _click = null;
    [SerializeField] private AudioClip _hover = null;

    private AudioSource _audioSource = null;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayClick() { 
        _audioSource.PlayOneShot(_click);
    }

    public void PlayHover()
    {
        _audioSource.PlayOneShot(_hover);
    }
}
