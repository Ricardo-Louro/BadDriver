using System;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public Axel axel;
    }

    [SerializeField] private float maxAcceleration = 35.0f;
    [SerializeField] private float breakAcceleration;

    [SerializeField] private List<Wheel> wheels;

    [SerializeField] private float turnSensitivity;
    [SerializeField] private float maxSteerAngle;

    private float moveInput;
    private float steerInput;

    private Rigidbody carRb;

    private void Start()
    {
        carRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetInputs();
    }

    private void LateUpdate()
    {
        Move();
        Steer();
    }

    private void GetInputs()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }

    private void Move()
    {
        foreach(var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput * maxAcceleration * Time.deltaTime;
        }
    }

    private void Steer()
    {
        foreach(var wheel in wheels)
        {
            if(wheel.axel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }

    }
}
