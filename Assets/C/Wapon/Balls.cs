using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    [SerializeField]
    private float torque;

    [SerializeField]
    private Rigidbody rigidbody;

    [SerializeField]
    private GameObject BoummVFX;

    [SerializeField] 
    private GameObject InstanceBoumVFX;

    [SerializeField]
    public AudioClip audioClip;
    public AudioSource BoummManager;


    private bool didHit;

    public void Fly(Vector3 force)
    {
        rigidbody.isKinematic = false;
        rigidbody.AddForce(force, ForceMode.Impulse);
        rigidbody.AddTorque(transform.right * torque);
        transform.SetParent(null);
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        
        if (!didHit)
        {
            BoummManager.PlayOneShot(audioClip);
            InstanceBoumVFX = Instantiate(BoummVFX, transform.position, Quaternion.identity);
            didHit = true;
            StartCoroutine(DestoryBall());
            
            
        }
    }

    public IEnumerator DestoryBall()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        Destroy(InstanceBoumVFX);
    }

}
