using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseWindow : Window
{
   [SerializeField] private GameObject pauseBtn;
   [SerializeField] private GameObject playBtn;
   [SerializeField] private GameObject exitBtn;
   [SerializeField] private GameObject restartBtn;

    [SerializeField] private PlayerView player;

    public override void On()
    {
        base.On();
        StartCoroutine(PausetBtn());
    }
    public void OnPlayButton()
    {
        Time.timeScale = 1;
        StartCoroutine(PlayBtn());
    }
    public void OnRestartButton()
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + player.GetScore());
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("isReincarnated", 0);
        StartCoroutine(RestartBtn());
    }
    public void OnExitButton()
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + player.GetScore());
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("isReincarnated", 0);
        StartCoroutine(ExitBtn());
    }

    private IEnumerator PausetBtn()
    {
        yield return new WaitForSeconds(0.25f);
        pauseBtn.SetActive(false);
        Time.timeScale = 0;
    }
    private IEnumerator PlayBtn()
    {
        yield return new WaitForSeconds(0.25f);
        pauseBtn.SetActive(true);
        base.Off();
    }
    private IEnumerator RestartBtn()
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene("PlayScene");
    }
    private IEnumerator ExitBtn()
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene("SampleScene"); ;
    }
}
