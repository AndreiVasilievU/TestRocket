using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PipeMover pipeMover;

    private Camera mainCamera;
    private Rigidbody rb;
    private Vector3 mousePos;
    private Vector3 position;
    private const float POS_Y = -2.6f;
    private bool isFly;
    private bool isImpulse;
    private ParticlesController PSController;

    [Header("Setup")]
    public float moveSpeed = 0.1f;
    public float impulsePower = 100f;
    public LayerMask layerMask;

    private void Awake()
    {
        PSController = GetComponent<ParticlesController>();
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        position = new Vector3(0, POS_Y, 0);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pipeMover.isActive = true;
            rb.useGravity = false;
            isFly = true;
            PSController.ChangeRate(25);
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit raycastHit,float.MaxValue, layerMask))
            {
                mousePos = raycastHit.point;
                mousePos.y = POS_Y;
            }

            position = Vector3.Lerp(transform.position, mousePos, moveSpeed);
            MouseLook();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isFly = false;
            pipeMover.isActive = false;
            rb.useGravity = true;
            rb.velocity = Vector3.zero;
            isImpulse = true;
            PSController.ChangeRate(0);
        }
    }

    private void FixedUpdate()
    {
        if (isFly)
        {
            rb.MovePosition(position);
        }
        else
        {
            SetImpulse();
        }
    }

    private void MouseLook()
    {
        Vector3 direction = new Vector3(
            mousePos.x - transform.position.x,
            mousePos.y - transform.position.y,
            mousePos.z - transform.position.z
            );

        transform.up = direction;
    }

    private void SetImpulse()
    {
        if (isImpulse)
        {
            rb.AddForce(transform.up * impulsePower, ForceMode.Impulse);
        }

        isImpulse = false;
    }

    public void Stop()
    {
        rb.isKinematic = true;
    }
}
