using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] float projectileSpeed;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.MovePosition(transform.position + transform.forward * Time.deltaTime * projectileSpeed);
        rb.AddForce(transform.forward * Time.deltaTime * projectileSpeed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        gameObject.SetActive(false);
    }
}
