using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    private Rigidbody rb;
    public float Speed;
	// Use this for initialization
	void Start ()
	{

	    rb = GetComponent<Rigidbody>();
        //перемещение объекторв
	    rb.velocity = transform.forward * Speed;
    }
	
}
