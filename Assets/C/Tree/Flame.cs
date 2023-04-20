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
            ScoreScript.scoreValue += 1;
            feux.SetActive(true);
            StartDestory();
        }
    }

    private void StartDestory()
    {
        Destroy(gameObject, 5f);
    }
}
