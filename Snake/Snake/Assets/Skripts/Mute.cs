using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    private bool muted;
    private AudioListener listener;
    private AudioManager audioManager;
    
    void Awake()
    {

        audioManager = gameObject.GetComponent<AudioManager>();
        listener= GameObject.FindObjectOfType<AudioListener>();


    }

    public void MuteOnClick()
    {

        muted = true;
        listener.enabled = false;


    }
    public void PlayOnClick()
    {

        muted = false;
        listener.enabled = true;

        audioManager.Play("Menu");
    }

}
