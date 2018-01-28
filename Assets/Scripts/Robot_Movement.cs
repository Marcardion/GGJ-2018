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
		
		Vector3 moveVector = new Vector3 (Input.GetAxisRaw ((controller.playerCode + "Horizontal")) * speed, mRigidbody.velocity.y, Input.GetAxisRaw ((controller.playerCode + "Vertical")) * speed);

		float hAxis = Mathf.Abs (Input.GetAxisRaw (controller.playerCode + "Horizontal"));
		float vAxis = Mathf.Abs (Input.GetAxisRaw (controller.playerCode + "Vertical"));

		if(hAxis >= 0.1 || vAxis >= 0.1)
		{
			controller.mAnimator.SetBool ("IsWalking", true);
			transform.forward = Vector3.RotateTowards(transform.forward, Vector3.Normalize(moveVector), Time.deltaTime*5f, 0.0F);
		} else 
		{
			controller.mAnimator.SetBool ("IsWalking", false);
		}
			


		mRigidbody.velocity = moveVector;

	}
}
