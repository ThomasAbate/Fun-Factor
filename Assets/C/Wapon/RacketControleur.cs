using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketControleur : MonoBehaviour
{

    [SerializeField]
    private Racket weapon;

    [SerializeField]
    private Animator Anim;

    [SerializeField]
    private string enemyTag;

    [SerializeField]
    private float maxFirePower;

    [SerializeField]
    private float firePowerSpeed;

    private float firePower;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private float minRotation;

    [SerializeField]
    private float maxRotation;

    [SerializeField] 
    private TrailRenderer trailRenderer;

    private float mouseY;

    private bool fire;

    void Start()
    {
        weapon.SetEnemyTag(enemyTag);
        weapon.Reload();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseY -= Input.GetAxis("Mouse Y") * rotateSpeed;
        mouseY = Mathf.Clamp(mouseY, minRotation, maxRotation);
        weapon.transform.localRotation = Quaternion.Euler(mouseY, weapon.transform.localEulerAngles.y, weapon.transform.localEulerAngles.z);

        if (Input.GetMouseButtonDown(0))
        {
            fire = true;
            Anim.SetBool("Press button", true);
        }

        if (fire && firePower < maxFirePower)
        {
            firePower += Time.deltaTime * firePowerSpeed;
        }

        if (fire && Input.GetMouseButtonUp(0))
        {
            weapon.Fire(firePower);
            firePower = 0;
            fire = false;
            Anim.SetBool("Press button", false);
        }

        
    }
}
