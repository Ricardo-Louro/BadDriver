using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    [SerializeField] private float speedValue;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        CarMovement carMov = other.GetComponentInParent<CarMovement>();
        if(carMov != null)
        {
            carMov.Rb.AddForce(transform.forward * speedValue, ForceMode.Force);
        }
    }
}