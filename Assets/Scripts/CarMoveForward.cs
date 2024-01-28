using System;
using UnityEngine;

public class CarMoveForward : MonoBehaviour
{
    [SerializeField] private bool       gameStart;
    [SerializeField] private float      moveSpeed;
    [SerializeField] public bool        grounded = false;
    
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if(gameStart && grounded)
        {
            rb.velocity = transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}