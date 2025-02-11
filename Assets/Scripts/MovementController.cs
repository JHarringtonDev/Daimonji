using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{

    float xInput;
    float yInput;
    float moveSpeed;

    [SerializeField] float groundspeed;
    [SerializeField] float airSpeed;
    [SerializeField] float mouseSpeed;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashDelay;
    [SerializeField] Image dashDisplay;

    [Header("Ground Check")]
    [SerializeField] float groundDrag;
    [SerializeField] float playerHeight;
    [SerializeField] LayerMask groundLayer;
    bool isGrounded;
    bool canDash;
    bool isDashing;

    Rigidbody rb;
    CapsuleCollider capsuleCollider;

    CameraControl cameraHold;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraHold = FindObjectOfType<CameraControl>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame

    private void Update()
    {
        //Vector3 mouseInput = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        //transform.eulerAngles += mouseInput * mouseSpeed;

        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2 + 0.2f, groundLayer);

        if (isGrounded)
        {
            rb.drag = groundDrag;
            moveSpeed = groundspeed;
            if (!isDashing && !canDash)
            {
                RestoreDash();
            }
        }
        else
        {
            moveSpeed = airSpeed;
            if (!isDashing)
            {
                rb.drag = 0;
            }
        }

        if(Input.GetMouseButtonDown(0) && canDash && !isDashing)
        {
            StartCoroutine(HandleDash());
        }
    }

    void LateUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        Vector3 playerInput = cameraHold.transform.forward * yInput + cameraHold.transform.right * xInput;
        playerInput.y = 0;

        rb.AddForce (playerInput * moveSpeed, ForceMode.Force);
    }

    IEnumerator HandleDash()
    {
        rb.velocity = Vector3.zero;
        rb.drag = groundDrag;
        isDashing = true;
        canDash = false;
        dashDisplay.color = Color.grey;
        AudioManager.PlaySound("dash");
        rb.AddForce(cameraHold.transform.forward * dashSpeed, ForceMode.Impulse);
        yield return new WaitForSeconds(dashDelay);
        rb.drag = 0;
        isDashing = false;
    }

    public void RestoreDash()
    {
        canDash = true;
        dashDisplay.color = Color.white;
    }

    public bool GetDashing()
    {
        return isDashing;
    }

    public void winningDash()
    {
        capsuleCollider.enabled = false;
        rb.AddForce(cameraHold.transform.forward * dashSpeed, ForceMode.Impulse);
    }

    public void StopVelocity()
    {
        rb.velocity = Vector3.zero;
    }
}
