using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField] private float chaseDistance;
    [SerializeField] private float chaseSpeed;
    private GameObject player;
    [SerializeField] private Rigidbody carRb;
    private Rigidbody rb;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceVector = player.transform.position - transform.position;

        transform.LookAt(player.transform.position);

        if(distanceVector.magnitude > chaseDistance)
{
            Vector3 velocityVector = transform.forward * (chaseSpeed * Time.deltaTime);
            rb.velocity = velocityVector;
        }
        else
        {
            Vector3 velocityVector = transform.forward * carRb.velocity.magnitude;
            rb.velocity = velocityVector;
        }
    }
}
