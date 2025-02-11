using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRune : MonoBehaviour
{
    [SerializeField] Material activatedMaterial;
    [SerializeField] MeshRenderer smallRune;
    MeshRenderer bigRuneMesh;
    Light glowLight;

    MovementController player;
    ExitDoor exitDoor;
    bool isActivated;

    // Start is called before the first frame update
    void Start()
    {
        bigRuneMesh = GetComponent<MeshRenderer>();
        glowLight = GetComponent<Light>();


        player = FindObjectOfType<MovementController>();
        exitDoor = FindObjectOfType<ExitDoor>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MovementController>() != null)
        {
            if (player.GetDashing() && !isActivated)
            {
                AudioManager.PlaySound("rune");
                player.StopVelocity();
                bigRuneMesh.material = activatedMaterial;
                smallRune.material = activatedMaterial;
                exitDoor.ActivateRune();
                glowLight.color = Color.blue;
            }
        }
    }
}
