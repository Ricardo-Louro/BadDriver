using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnValidate : MonoBehaviour
{
    [SerializeField] private GameObject         bullet;
    [SerializeField] private Transform          spawnPoint;
    [SerializeField] private float              bulletSpeed = 20f;
    
    [SerializeField] private float              fireCooldown;
    private float                               lastTimeFired;

    [SerializeField] private float              maxAmmo;
    private float                               currentAmmo;

    // Start is called before the first frame update
    private void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        if(currentAmmo > 0 && Time.time > lastTimeFired + fireCooldown)
        {
            lastTimeFired = Time.time;
            currentAmmo -= 1;
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = spawnPoint.position;
            spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletSpeed;
            Destroy(spawnedBullet, 5);
        }
    }
}