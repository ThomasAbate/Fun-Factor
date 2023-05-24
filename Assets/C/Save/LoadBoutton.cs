using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadBoutton : MonoBehaviour
{
    public GameObject loadingScreen; 
    public Slider progressBar;
    public Text progressText;
    public void Load()
    {
        StartCoroutine(LoadingScreen());

        string saveFilePath = Application.persistentDataPath + "/save.fsav";

        StreamReader sr = new StreamReader(saveFilePath);
        string jsonString = sr.ReadToEnd();

        sr.Close();
        JObject jObject = JObject.Parse(jsonString);

        _lvl = (int)jObject["Data"]["Level"];
    }

    private IEnumerator LoadingScreen()
    {
        loadingScreen.SetActive(true);
        AsyncOperation async = SceneManager.LoadSceneAsync("Terin de tennis");
        while (!async.isDone)
        {
            progressBar.fillAmount = async.progress;
            if (async.progress >= 0.95f)
            {
                progressText.text = "Press Space to continue";
            }
            yield return null;
        }
        if (Input.GetKey(KeyCode.Space)) async.allowSceneActivation = true;
        loadingScreen.SetActive(false);

    }
