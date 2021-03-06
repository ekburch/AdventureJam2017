﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerController : MonoBehaviour 
{
	public float speed;

	private Rigidbody rb;
	 
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.W))
			rb.velocity = new Vector3(0f, rb.velocity.y, speed);
		if(Input.GetKey(KeyCode.S))
			rb.velocity = new Vector3(0f, rb.velocity.y, -speed);
		if(Input.GetKey(KeyCode.D))
			rb.velocity = new Vector3(speed, rb.velocity.y, 0f);
		if(Input.GetKey(KeyCode.A))
			rb.velocity = new Vector3(-speed, rb.velocity.y, 0f);	
	}
}
