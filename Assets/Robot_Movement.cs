using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Movement : MonoBehaviour {

	[SerializeField] private float speed;

	private Rigidbody mRigidbody;

	private PlayerController controller;

	// Use this for initialization
	void Start () {

		mRigidbody = GetComponent<Rigidbody> ();
		controller = GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		Move ();
		
	}

	void Move()
	{
		
		Vector3 moveVector = new Vector3 (Input.GetAxisRaw ((controller.playerCode + "Horizontal")) * speed, 0, Input.GetAxisRaw ((controller.playerCode + "Vertical")) * speed);

		mRigidbody.velocity = moveVector;

	}
}
