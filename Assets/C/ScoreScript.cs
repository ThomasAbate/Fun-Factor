using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    public Text score;
    public GameObject Sound1kill;
    public GameObject Sound10kill;
    public GameObject Sound20kill;
    public GameObject Sound40kill;
    public GameObject Sound60kill;
    public GameObject Sound100kill;

    public GameObject xUI;
    public GameObject x2;
    public GameObject x4;

    void Start()
    {
        score = GetComponent<Text>();
    }

 
    void Update()
    {
        score.text = scoreValue.ToString();

        if (scoreValue >= 1)
        {
            Sound1kill.SetActive(true);
        }
        
        if (scoreValue >= 10)
        {
            Sound10kill.SetActive(true);
        }

        if (scoreValue >= 20)
        {
            xUI.SetActive(true);
            Sound20kill.SetActive(true);
        }

        if (scoreValue >= 40)
        {
            Sound40kill.SetActive(true);
        }

        if (scoreValue >= 60)
        {
            x2.SetActive(false);
            Sound60kill.SetActive(true);
            x4.SetActive(true);
        }

        if (scoreValue >= 100)
        {
            Sound100kill.SetActive(true);
        }

        if (scoreValue >= 140) 
        {
            Invoke("ToEnd", 2f);
        }
    }

    public void ToEnd()
    {
        SceneManager.LoadScene("End");
    }
}
