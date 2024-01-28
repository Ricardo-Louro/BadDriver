using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField] private float chaseDistance;
    [SerializeField] private float chaseSpeed;
    private GameObject player;
    private Rigidbody playerRb;
    private Rigidbody rb;
   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerRb = player.GetComponentInParent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceVector = player.transform.position - transform.position;
        
        transform.LookAt(player.transform.position);

        if(distanceVector.magnitude > chaseDistance)
        {
            rb.velocity = transform.forward * chaseSpeed * Time.deltaTime;
        }
        else
        {
            rb.velocity = transform.forward * playerRb.velocity.magnitude;
        }
    }
}
