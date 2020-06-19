using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;

    [SerializeField] private GameObject mainCamera;

    [SerializeField] private GameObject soundToggle;
    [SerializeField] private GameObject musicToggle;
    [SerializeField] private GameObject slider;

    [SerializeField] private GameObject applyBtn;
    [SerializeField] private GameObject closeBtn;

     private GameObject[] Btns;

    private bool isVolumeActive;
    private bool isSoundActive;
    private float soundValue=100;

    private AudioSource mainMenuMusic;

    private float TIME_END_ANIM = 0.25f;

    private bool isMusicEnabled;

    void Start()
    {
        settingsMenu.SetActive(false);
        mainMenuMusic=mainCamera.GetComponent<AudioSource>();
        slider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Volume");
        InitializeEnabledMusic();
        InitializeButtonsSound();
    }

    public void OnSettingsClick()
    {
        settingsMenu.SetActive(true);
    }
    public void OnApplyClick()
    {
        // Реализовать сохранение настроек
        StartCoroutine(WaitEndAnimation());
        
    }
    public void OnCloseClick()
    {
        StartCoroutine(WaitEndAnimation());
    }

   
    public void OnMusicToggleClick()
    {
       bool isOn=musicToggle.GetComponent<Toggle>().isOn;
        if (isOn)
        {
            mainMenuMusic.enabled = true;
            PlayerPrefs.SetInt("Music", 1);
        }
        else
        {
            mainMenuMusic.enabled = false;
            PlayerPrefs.SetInt("Music", 0);
        }


    }
    public void OnSoundToggleClick()
    {
        bool isOn = soundToggle.GetComponent<Toggle>().isOn;
        Btns = GameObject.FindGameObjectsWithTag("Button");

        if (isOn)
        {
            foreach (GameObject btn in Btns)
            { 
             btn.GetComponent<AudioSource>().enabled = true;
            }
            PlayerPrefs.SetInt("Sound",1);
        }
        if(!isOn)
        {
            foreach (GameObject btn in Btns)
            {
                btn.GetComponent<AudioSource>().enabled = false;
            }
            PlayerPrefs.SetInt("Sound", 2);
        }
      
    }

    public void OnSLiderChange()
    {
      AudioSource[] allAuidio= GameObject.FindObjectsOfType<AudioSource>();
        foreach(AudioSource src in allAuidio)
        {
            src.volume= slider.GetComponent<Slider>().value;
            PlayerPrefs.SetFloat("Volume", src.volume);
        }
    }

    private IEnumerator WaitEndAnimation()
    {
        yield return new WaitForSeconds(TIME_END_ANIM);
        settingsMenu.SetActive(false);
    }
    private void InitializeEnabledMusic()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            mainMenuMusic.enabled = true;
            musicToggle.GetComponent<Toggle>().isOn = true;
        }
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            mainMenuMusic.enabled = false;
            musicToggle.GetComponent<Toggle>().isOn = false;
        }
    }
    private void InitializeButtonsSound()
    {
        GameObject[] Btns = GameObject.FindGameObjectsWithTag("Button");

        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            foreach (GameObject btn in Btns)
            {
                btn.GetComponent<AudioSource>().enabled = true;
                
            }
            soundToggle.GetComponent<Toggle>().isOn = true;
        }
        if (PlayerPrefs.GetInt("Sound") == 2)
        {
            foreach (GameObject btn in Btns)
            {
                btn.GetComponent<AudioSource>().enabled = false;
              
            }
            soundToggle.GetComponent<Toggle>().isOn = false;
        }
    }
}
