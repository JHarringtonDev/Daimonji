using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Pool;

public class EnemyScript : MonoBehaviour
{
    MovementController player;

    private void Start()
    {
        player = FindObjectOfType<MovementController>();
        Invoke("FireProjectile", 5);
    }

    private void Update()
    {
        transform.LookAt(player.transform.position);
    }

    void FireProjectile()
    {
        GameObject bullet = ProjectilePool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
    }

}
