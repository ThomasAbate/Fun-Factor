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
    private Boum BoummManager;


    private string enemyTag;

    private bool didHit;

    public void SetEnemyTag(string enemyTag)
    {
        this.enemyTag = enemyTag;
    }

    public void Fly(Vector3 force)
    {
        rigidbody.isKinematic = false;
        rigidbody.AddForce(force, ForceMode.Impulse);
        rigidbody.AddTorque(transform.right * torque);
        transform.SetParent(null);
    }

    private void Start()
    {
        BoummManager = gameObject.GetComponent<Boum>();
    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.CompareTag(enemyTag))
        {
            Debug.Log("jai mal");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!didHit)
        {
            BoummManager._Boum(0);
            BoummVFX.SetActive(true);
            didHit = true;
        }

        BoummVFX.SetActive(false);
    }
}
