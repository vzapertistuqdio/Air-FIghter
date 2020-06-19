using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsSystem : MonoBehaviour
{
    private PauseWindow pauseWindow;
    private DeathWindow deathWindow;
    private void Start()
    {
        pauseWindow = GetComponent<PauseWindow>();
        deathWindow = GetComponent<DeathWindow>();
        DisablePauseWindow();
        DisableDeathWindow();
            
    }
    public void EnablePauseWindow()
    {
        pauseWindow.On();
    }
    public void DisablePauseWindow()
    {
        pauseWindow.Off();
    }
    public void EnableDeathWindow()
    {
        deathWindow.On();
    }
    public void DisableDeathWindow()
    {
        deathWindow.Off();
    }
}
