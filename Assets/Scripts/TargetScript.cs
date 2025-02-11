using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    MovementController player;
    [SerializeField] bool isEnemy;
    [SerializeField] int maxHealth;
    [SerializeField] float deathTime;
    int currentHealth;

    private void Start()
    {
        player = FindObjectOfType<MovementController>();
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        player.RestoreDash();
        if (isEnemy && currentHealth > 0)
        {
            currentHealth--;
        }
        else
        {
            deactivateTarget();
        }
    }

    void deactivateTarget()
    {
        if (!isEnemy)
        {
            AudioManager.PlaySound("gem");
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            StartCoroutine(DisableEnemy());
        }
    }

    public void reactivateTarget()
    {
        if (!isEnemy)
        {
            GetComponent<SphereCollider>().enabled = true;
            GetComponent<MeshRenderer>().enabled = true;
        }
    }

    IEnumerator DisableEnemy()
    {
        yield return new WaitForSeconds(deathTime);
    }
}
