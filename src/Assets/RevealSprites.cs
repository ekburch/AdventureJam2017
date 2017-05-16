using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class RevealSprites : MonoBehaviour 
{
	public SpriteRenderer spirit;
	public Flowchart flowchart;

	// Use this for initialization
	void Start () 
	{
		bool spiritTriggered = flowchart.GetVariable<BooleanVariable>("spiritTriggered").Value;
		spiritTriggered = false;
		spirit.enabled = false;
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) 
	{
		if(other.gameObject.CompareTag("Player"))
		{
			flowchart.SetBooleanVariable("spiritTriggered", true);
			spirit.enabled = true;
			//flowchart.SendMessage("Reveal yourself!", SendMessageOptions.RequireReceiver);
		}
	}
}
