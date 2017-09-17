using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    private Rigidbody rb;
    public float tumble;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //изменяем угловую скорость объекта используя рандомную сферу
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
