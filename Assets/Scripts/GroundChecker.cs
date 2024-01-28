using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private new Collider collider;
    private CarMoveForward carMoveForward;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
    }


}
