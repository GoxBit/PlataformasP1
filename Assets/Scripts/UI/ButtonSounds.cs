using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    [SerializeField] private AudioClip _click = null;
    [SerializeField] private AudioClip _hover = null;
    [SerializeField] private float tweenTime = 0.5f;

    private AudioSource _audioSource = null;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Animation() {
        LeanTween.scale(gameObject, Vector3.one * 1.1f, tweenTime).setEasePunch();
    }

    public void PlayClick() { 
        _audioSource.PlayOneShot(_click);
    }

    public void PlayHover()
    {
        Animation();
        _audioSource.PlayOneShot(_hover);
    }
}
