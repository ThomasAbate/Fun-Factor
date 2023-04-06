using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoumVFX : MonoBehaviour
{

    [SerializeField]
    private GameObject BoummVFX;

    [SerializeField]
    private SphereCollider Collider;


    private void OnCollisionEnter(Collision collision)
    {
        BoummVFX.SetActive(true);
        Collider.enabled = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        BoummVFX.SetActive(false);
        Collider.enabled = false;
    }
}
