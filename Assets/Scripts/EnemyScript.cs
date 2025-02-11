using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    MovementController player;

    private void Start()
    {
        player = FindObjectOfType<MovementController>();
    }

    private void Update()
    {
        transform.LookAt(player.transform.position);
    }
}
