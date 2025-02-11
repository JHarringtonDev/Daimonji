using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLevel : MonoBehaviour
{
    TargetScript[] targets;
    // Start is called before the first frame update
    void Start()
    {
        targets = FindObjectsOfType<TargetScript>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (var target in targets)
            {
                target.reactivateTarget();
            }
        }
    }
}
