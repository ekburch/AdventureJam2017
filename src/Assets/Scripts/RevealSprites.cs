using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.Events;

public class RevealSprites : MonoBehaviour
{
    public SpriteRenderer spirit;
    public UnityEvent TriggerEnter;

    // Use this for initialization
    void Start()
    {
        //bool spiritTriggered = flowchart.GetVariable<BooleanVariable>("spiritTriggered").Value;
        //spiritTriggered = false;
        spirit.enabled = false;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.Player))
        {
            //flowchart.SetBooleanVariable("spiritTriggered", true);
            spirit.enabled = true;
            //flowchart.SendMessage("Reveal yourself!", SendMessageOptions.RequireReceiver);

            if (TriggerEnter != null)
            {
                TriggerEnter.Invoke();
            }
        }
    }

    void OnTriggerExit (Collider other)
    {
		if (other.gameObject.CompareTag("Player"))
        {
        	this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
