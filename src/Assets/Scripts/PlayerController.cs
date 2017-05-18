using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PlayerController : MonoBehaviour 
{
	public static PlayerController Instance { get; set; }

	public enum State {Move, Dialog};
	public State currState;

	public float xVal;
    public float yVal;

    public float speed = 5f;

    public GameObject ground;

    public Vector3 target;
    public Vector3 tempPos;
	public Vector3 mouseDragPos;
    public Vector3 mouseDownPos;

	public Flowchart flowchart;

    public bool stopMoving = false;
    
    private bool moveToPos = false;
        
    void Start ()
   	{
   		Instance = this;
		xVal = Input.GetAxis("Mouse X");
        yVal = Input.GetAxis("Mouse Y");
   	}

    void Update()
    {   
    	switch (currState)
    	{   
    		case State.Move:
	    		currState = State.Move;
	    		stopMoving = false;
				MovePlayer();
		   		break;

		   	case State.Dialog:
		   		currState = State.Dialog;
		   		stopMoving = true;
		   		StopMoving();
		   		break;
        }
	}

	public void MovePlayer()
	{
		currState = State.Move;
		if (Input.GetMouseButton (0)) 
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (ground.GetComponent<Collider>().Raycast (ray, out hit, Mathf.Infinity)) 
            {
                tempPos = transform.position;
                tempPos.y = hit.point.y;
                tempPos.x = hit.point.x;
                tempPos.z = hit.point.z;
                moveToPos = true;
            }
         }

        if(moveToPos)
        {
            Vector3 tempV3 = (tempPos - transform.position).normalized * speed;
            tempV3.y -= 2;
            GetComponent<Rigidbody>().velocity = tempV3;

            if (Vector3.Distance(transform.position, tempPos) < 1)
            {
                moveToPos = false;   
				GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            }
        }
	}

	public void MoveToPos(Vector3 tarPos)
    {
        for(int i = 0; i < 100; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, tarPos, speed * Time.deltaTime);
        }
    }

    public void StopMoving()
    {
    	currState = State.Dialog;
    	GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
    }
}
