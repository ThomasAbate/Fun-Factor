using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float torque;

    [SerializeField]
    private Rigidbody rigidbody;

    [SerializeField]
    private GameObject BoummVFX;

    [SerializeField] 
    private GameObject PrefabBoumVFX;

    [SerializeField]
    private SoundBoum BoummManager;

    private bool didHit;

    public void Fly(Vector3 force)
    {
        rigidbody.isKinematic = false;
        rigidbody.AddForce(force, ForceMode.Impulse);
        rigidbody.AddTorque(transform.right * torque);
        transform.SetParent(null);
    }

    private void Start()
    {
        BoummManager = gameObject.GetComponent<SoundBoum>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!didHit)
        {
            PrefabBoumVFX = Instantiate(BoummVFX, transform.position, Quaternion.identity);
            Destroy(PrefabBoumVFX, 3f);
            BoummManager._Boum(0);
            didHit = true;
        }

        
    }
}
