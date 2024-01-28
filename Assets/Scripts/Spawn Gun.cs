using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gunPrefab;
    [SerializeField] private Transform spawnPoint;

    public void SpawnGun()
    {
        GameObject gun = Instantiate(gunPrefab);
        gun.transform.position = spawnPoint.position;
    }
}
