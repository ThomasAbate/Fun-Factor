using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoumVFX : MonoBehaviour
{

    [SerializeField]
    private GameObject BoummVFX;


    private void OnCollisionEnter(Collision collision)
    {
        BoummVFX.SetActive(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        BoummVFX.SetActive(false);
    }
}
