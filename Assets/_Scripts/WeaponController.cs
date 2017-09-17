using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    public float fireDelay;

    private AudioSource audioSource;

	// Use this for initialization
	void Start ()
	{
	    audioSource = GetComponent<AudioSource>();
	}

    void Update()
    {
        //при нажатии происходит появление выстрела
        //InvokeRepeating("Fire", fireDelay, fireRate);
        if (Time.time > fireDelay)
        {
            fireDelay = Time.time + fireRate;
            Fire();
        }

    }

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        GetComponent<AudioSource>().Play();
    }
}
