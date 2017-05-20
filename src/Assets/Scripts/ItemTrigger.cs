using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Fungus;

public class ItemTrigger : MonoBehaviour 
{
	public UnityEvent TriggerEnter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Player))
        {
            if (TriggerEnter != null)
            {
                TriggerEnter.Invoke();
            }
        }
    }
    //This is so sloppy and incorrect but I'm tired and this will have to do.
    public void EnableCollider ()
    {
    	this.GetComponent<BoxCollider>().enabled = true;
    }

    public void DisableCollider ()
    {
    	this.GetComponent<BoxCollider>().enabled = false;
    }
}
