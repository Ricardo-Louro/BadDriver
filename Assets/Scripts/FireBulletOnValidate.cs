using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnValidate : MonoBehaviour
{
    private Transform                           playerTransform;
    [SerializeField] private float              maxDistanceAllowed;
    [SerializeField] private GameObject         bullet;
    [SerializeField] private Transform          spawnPoint;
    [SerializeField] private float              bulletSpeed = 20f;
    
    [SerializeField] private float              fireCooldown;
    private float                               lastTimeFired;

    [SerializeField] private float              maxAmmo;
    private float                               currentAmmo;

    private ParticleSystem                      muzzleFlash;
    private Animator                            animator;

    [SerializeField] private AudioSource        emptyGunSound;
    [SerializeField] private AudioSource        shootSound;

    // Start is called before the first frame update
    private void Start()
    {
        playerTransform = FindObjectOfType<CarMoveForward>().transform;
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
        currentAmmo = maxAmmo;
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if ((transform.position - playerTransform.position).magnitude > maxDistanceAllowed)
        {
            Destroy(gameObject);
        }
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
            muzzleFlash.Play();
            shootSound.Play();
            animator.SetTrigger("shooting");
        }
        else if(currentAmmo <= 0)
        {
            emptyGunSound.Play();
        }
    }
}