using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget_Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("w")) 
		{
			MoveTo (0);
		}
		if (Input.GetKeyDown ("a")) 
		{
			MoveTo (3);
		}
		if (Input.GetKeyDown ("d")) 
		{
			MoveTo (1);
		}
		if (Input.GetKeyDown ("s")) 
		{
			MoveTo (2);
		}
		
	}

	void MoveTo(int direction)
	{
		switch (direction) 
		{
		case 0:
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 20);
			break;
		case 1:
			transform.position = new Vector3(transform.position.x + 25, transform.position.y, transform.position.z);
			break;
		case 2:
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 20);
			break;
		case 3:
			transform.position = new Vector3(transform.position.x - 25, transform.position.y, transform.position.z);
			break;
		}
	}

	public void MoveTo(Vector3 newPosition)
	{
		transform.position = newPosition;
	}
}
