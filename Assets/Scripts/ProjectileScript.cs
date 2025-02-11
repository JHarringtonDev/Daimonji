using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    MovementController player;

    Rigidbody rb;

    private void Awake()
    {
        player = FindObjectOfType<MovementController>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.velocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * projectileSpeed * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        gameObject.SetActive(false);
    }
}
