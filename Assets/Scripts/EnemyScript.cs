using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Pool;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    [SerializeField] float playerRangeDelay;
    [SerializeField] float fireDelay;
    [SerializeField] Material activeRuneMaterial;
    [SerializeField] MeshRenderer connectedRune;

    MovementController player;
    ExitDoor exitDoor;

    bool canFire = true;

    private void Start()
    {
        player = FindObjectOfType<MovementController>();
        exitDoor = FindObjectOfType<ExitDoor>();
    }

    private void Update()
    {
        if(Physics.Raycast(transform.position, player.transform.position - transform.position, 25, playerLayer))
        {
            transform.LookAt(player.transform.position);
            if(canFire)
            {
                StartCoroutine(HandleProjectile());
            }
        }
    }

    IEnumerator HandleProjectile()
    {
        canFire = false;
        //yield return new WaitForSeconds(playerRangeDelay);
        StartCoroutine(FireProjectile());
        yield return new WaitForSeconds(fireDelay);
        canFire = true;
    }

    IEnumerator FireProjectile()
    {
        GameObject bullet = ProjectilePool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            yield return new WaitForSeconds(1f);
            bullet.SetActive(true);
        }
    }

    private void OnDisable()
    {
        connectedRune.material = activeRuneMaterial;
        exitDoor.ActivateRune();
    }

}
