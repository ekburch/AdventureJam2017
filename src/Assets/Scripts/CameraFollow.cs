using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CameraFollow : MonoBehaviour 
{
	public Transform target;
	public float smoothing;
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;
	Vector3 offset;
	// Use this for initialization
	void Start () 
	{
		offset = transform.position - target.position;	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, xMin, xMax), 
										 transform.position.y,
										 (Mathf.Clamp (transform.position.z, zMin, zMax)));
	}
}
