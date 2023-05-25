using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flame : MonoBehaviour
{
    [SerializeField]
    public GameObject feux;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            ScoreScript.instance.scoreValue += 1;
            Save.instance.Savee(ScoreScript.instance.scoreValue);
            feux.SetActive(true);
            StartDestory();
        }
    }

    private void StartDestory()
    {
        Destroy(gameObject, 5f);
    }
}
