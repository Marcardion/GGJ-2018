using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget_Move : MonoBehaviour {

	[SerializeField] private GameObject p1;
	[SerializeField] private GameObject p2;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		FindMiddlePoint ();
	}

	void FindMiddlePoint()
	{
		Vector3 middlepoint = (p1.transform.position + p2.transform.position) / 2f;
		middlepoint.y = 0.5f;
		transform.position = middlepoint;
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
