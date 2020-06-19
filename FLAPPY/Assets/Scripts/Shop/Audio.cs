using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    private AudioSource shopMusic;
    void Start()
    {
        shopMusic = GetComponent<AudioSource>();
        shopMusic.volume = PlayerPrefs.GetFloat("Volume");
        shopMusic = GetComponent<AudioSource>();
        InitializeButtonsSound();
        InitializeEnabledMusic();
    }

    private void InitializeButtonsSound()
    {
       GameObject[] Btns = GameObject.FindGameObjectsWithTag("Button");

        if (PlayerPrefs.GetInt("Sound")==1)
        {
            foreach (GameObject btn in Btns)
            {
                btn.GetComponent<AudioSource>().enabled = true;
            }
        }
        if (PlayerPrefs.GetInt("Sound") == 2)
        {
            foreach (GameObject btn in Btns)
            {
                btn.GetComponent<AudioSource>().enabled = false;
            }
        }
    }
    private void InitializeEnabledMusic()
    {
        if(PlayerPrefs.GetInt("Music")==1)
        {
            shopMusic.enabled = true;
        }
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            shopMusic.enabled = false;
        }
    }

}
