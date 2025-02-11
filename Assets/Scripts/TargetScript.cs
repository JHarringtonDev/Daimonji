using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    MovementController player;
    [SerializeField] bool isEnemy;
    [SerializeField] bool isProjectile;
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
        if (other.GetComponent<MovementController>() != null)
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isProjectile)
        {
            if (player.GetDashing())
            {
                player.RestoreDash();
                gameObject.SetActive(false);
            }
            else
            {
                player.TakeDamage();
                gameObject.SetActive(false);
            }
        }
    }

    void deactivateTarget()
    {
        if (!isEnemy && !isProjectile)
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
        if (!isEnemy && !isProjectile)
        {
            GetComponent<SphereCollider>().enabled = true;
            GetComponent<MeshRenderer>().enabled = true;
        }
    }

    IEnumerator DisableEnemy()
    {
        yield return new WaitForSeconds(deathTime);
        gameObject.SetActive(false);
    }
}
