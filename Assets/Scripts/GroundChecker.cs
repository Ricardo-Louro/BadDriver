using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private new Collider collider;
    private CarMoveForward carMoveForward;

    // Start is called before the first frame update
    private void Start()
    {
        collider = GetComponent<Collider>();
        carMoveForward = GetComponentInParent<CarMoveForward>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit the ground");
        carMoveForward.grounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("left the ground");
        carMoveForward.grounded = false;
    }
}
