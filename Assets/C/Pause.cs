using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public AudioSource Audiosource;
    public Slider music;

    public GameObject pauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Save.instance.LoadOptions();
        music.value = Save.instance.music;
        Audiosource.volume = Save.instance.music;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Save.instance.SaveOptions();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Resume();
        Save.instance.Savee(ScoreScript.instance.scoreValue);
        Save.instance.SaveOptions();
        SceneManager.LoadScene("Menu");
    }

    public void VolumSlider()
    {
        Audiosource.volume = music.value;
    }
}

