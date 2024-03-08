using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemySpawner spawner;
    private Chaser chaser;
    private Rigidbody rb;
    [SerializeField] private int health;
    [SerializeField] private int seconds;

    private void Start()
    {
        spawner = FindObjectOfType<EnemySpawner>();
        chaser = gameObject.GetComponent<Chaser>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(health == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(chaser);

        rb.velocity = new Vector3();

        //TRIGGER DEATH ANIMATION
        StartCoroutine(WaitToDestroy(seconds));
    }

    private IEnumerator WaitToDestroy(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            health--;
        }
    }
}
