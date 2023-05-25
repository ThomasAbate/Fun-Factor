using Newtonsoft.Json.Linq;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Collections.Generic;
public class Save : MonoBehaviour
{
    public static Save instance;

    #region Options to save
    public float music;
    public Slider musicSlider;
    #endregion
    public int score;
    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
    }
    public void Savee(int score_)
    {
        score = score_;
        string saveFilePath = Application.persistentDataPath + "/Save.data";
        JObject jObject = new JObject
        {
            { "Component Name", GetType().ToString() }
        };
        JObject jDataObject = new JObject();
        jObject.Add("Data", jDataObject);
        jDataObject.Add("Score", score);
        StreamWriter sw = new StreamWriter(saveFilePath);
        sw.WriteLine(jObject.ToString());
        sw.Close();
    }
    public void Load()
    {
        string saveFilePath = Application.persistentDataPath + "/Save.data";
        StreamReader sr = new StreamReader(saveFilePath);
        string jsonString = sr.ReadToEnd();
        sr.Close();
        JObject jObject = JObject.Parse(jsonString);
        score = (int)jObject["Data"]["Score"];
        ScoreScript.instance.scoreValue = score;
    }
   
    public void SaveOptions()
    {
        music = musicSlider.value;
        string saveFilePath = Application.persistentDataPath + "/SaveOption.data";
        JObject jObject = new JObject
        {
            { "NOM", GetType().ToString() }
        };
        JObject jOptionsDataObject = new JObject();
        jObject.Add("Options", jOptionsDataObject);
        jOptionsDataObject.Add("Music", music);
        StreamWriter sw = new StreamWriter(saveFilePath);
        sw.WriteLine(jObject.ToString());
        sw.Close();
    }
    public void LoadOptions()
    {
        if (!File.Exists(Application.persistentDataPath + "/SaveOption.data"))
        {
            music = musicSlider.maxValue;
        }
        else
        {
            string saveFilePath = Application.persistentDataPath + "/SaveOption.data";
            StreamReader sr = new StreamReader(saveFilePath);
            string jsonString = sr.ReadToEnd();
            sr.Close();
            JObject jObject = JObject.Parse(jsonString);
            music = (float)jObject["Options"]["Music"];
        }
    }
}

