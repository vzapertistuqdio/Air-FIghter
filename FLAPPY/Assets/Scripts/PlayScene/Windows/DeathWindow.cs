using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathWindow : Window
{
    [SerializeField] private GameObject exitBtn;
    [SerializeField] private GameObject restartBtn;
    [SerializeField] private GameObject reincarnationtBtn;

    [SerializeField] private GameObject[] needToDIsable;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text destroyEnemiesText;
    [SerializeField] private Text destroyRocketText;

    [SerializeField] private PlayerView player;
    public override void On()
    {
        scoreText.text = player.GetScore().ToString();
        destroyEnemiesText.text = player.GetDestroyedEnemies().ToString();
        destroyRocketText.text= player.GetDestroyedRocket().ToString();
        if (Inventory.GetInstance().CheckItem(301) && PlayerPrefs.GetInt("isReincarnated")== 0)
            reincarnationtBtn.SetActive(true);
        else reincarnationtBtn.SetActive(false);
        foreach (GameObject obj in needToDIsable)
        {
            obj.SetActive(false);
        }
        base.On();
    }
    public void OnRestartButton()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("isReincarnated", 0);
        StartCoroutine(RestartBtn());
    }
    public void OnExitButton()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("isReincarnated", 0);
        StartCoroutine(ExitBtn());
    }
    public void OnReincarntationButton()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Score",player.GetScore());
        PlayerPrefs.SetInt("isReincarnated",1);
        SceneManager.LoadScene("PlayScene");
        this.Off();
        
    }
    private IEnumerator RestartBtn()
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene("PlayScene");
    }
    private IEnumerator ExitBtn()
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene("SampleScene");   
    }
}
