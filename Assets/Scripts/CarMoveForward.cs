using System;
using UnityEngine;

public class CarMoveForward : MonoBehaviour
{
    [SerializeField] private bool       gameStart = true;
    [SerializeField] private float      moveSpeed;
    
    private Rigidbody rb;
    public Rigidbody Rb => rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if(gameStart)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, moveSpeed * Time.deltaTime);
        }
    }
}