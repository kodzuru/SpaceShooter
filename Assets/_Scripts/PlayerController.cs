using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;

  
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        //организация выстрелов героя
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //при нажатии происходит появление выстрела
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // as GameObject;
            GetComponent<AudioSource>().Play();
        }
    }

    //FixedUpdate Update using physics per frame
    void FixedUpdate()
    {
        //движение объекта в плоскоси
        float moveHorisontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorisontal, 0.0f, moveVertical);
        rb.velocity = movement * speed; // скорость движения

        //при движении лево-право герой поворачивается на небольшой угол
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

}
