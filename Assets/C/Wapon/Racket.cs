using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    [SerializeField]
    private float reloadTime;

    [SerializeField]
    private Balls BallPrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private Transform BallsPoint;

    private Balls currentBalls;

    private bool isReloading;


    public void Reload()
    {
        if (isReloading || currentBalls != null) return;
        isReloading = true;
        StartCoroutine(ReloadAfterTime());
    }

    private IEnumerator ReloadAfterTime()
    {
        yield return new WaitForSeconds(reloadTime);
        currentBalls = Instantiate(BallPrefab, spawnPoint);
        currentBalls.transform.localPosition = Vector3.zero;
        isReloading = false;

    }

    public void Fire(float firePower)
    {
        if (isReloading || currentBalls == null) return;
        var force = spawnPoint.TransformDirection(Vector3.forward * firePower);
        currentBalls.Fly(force);
        currentBalls = null;
        DestroyCureentBalls();
        Reload();
    }

    public bool IsReady()
    {
        return (!isReloading && currentBalls != null);
    }

    private void DestroyCureentBalls()
    {
            Destroy(currentBalls, 3f);
    }
}
