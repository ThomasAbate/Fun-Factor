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
    private GameObject InstanceBoumVFX;

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
            InstanceBoumVFX = Instantiate(BoummVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Destroy(InstanceBoumVFX, 3f);
        didHit = true;
    }
}
