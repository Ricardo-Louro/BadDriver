using System;
using UnityEngine;

public class CarMoveForward : MonoBehaviour
{
    [SerializeField] private float      moveSpeed;

    private Vector3 moveVector;
    
    private Rigidbody rb;
    public Rigidbody Rb => rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveVector = rb.position;
    }
    private void FixedUpdate()
    {
        moveVector.z += moveSpeed * Time.fixedDeltaTime;
        rb.position = moveVector;
    }
}