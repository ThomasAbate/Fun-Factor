using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start : MonoBehaviour
{
    public AudioSource Audiosource;
    public Slider music;

    
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Save.instance.LoadOptions();
        music.value = Save.instance.music;
        Audiosource.volume = Save.instance.music;
    }
    public void Commncer() 
    {
        Save.instance.SaveOptions();
        File.Delete(Application.persistentDataPath + "/Save.data");
        SceneManager.LoadScene("Terin de tennis");
    }

    public void Load()
    {
        if (!File.Exists(Application.persistentDataPath + "/SaveOption.data"))
        {
            Commncer();
        }
        else
        {
            Save.instance.SaveOptions();
            Save.instance.Load();
            ScoreScript.instance.scoreValue = Save.instance.score;  
            SceneManager.LoadScene("Terin de tennis");         
        }
    }

    public void VolumSlider()
    {
        Audiosource.volume = music.value;
    }
        
}
