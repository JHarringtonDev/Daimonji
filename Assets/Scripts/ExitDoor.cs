using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] int runesToActivate;
    [SerializeField] float doorSpeed;
    [SerializeField] GameObject leftDoor;
    [SerializeField] GameObject rightDoor;
    [SerializeField] MeshCollider exitPlane;
    float doorRotation = 0;
    bool opening;

    private void Update()
    {
        if (opening && doorRotation < 100)
        {
            doorRotation += doorSpeed * Time.deltaTime;
        }

        leftDoor.transform.localEulerAngles = new Vector3 (0, doorRotation, 0);
        rightDoor.transform.localEulerAngles = new Vector3 (0,-doorRotation, 0);
    }

    void OpenDoor()
    {
        opening = true;
        exitPlane.enabled = true;
    }

    public void ActivateRune() 
    {
        runesToActivate--;

        if (runesToActivate == 0 ) 
        {
            OpenDoor();
            AudioManager.PlaySound("unlock");
            AudioManager.PlaySound("door");
        }
    }
}
