using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_ChangeLight : MonoBehaviour {

	[SerializeField] private Light mLight;

	private PlayerController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		ChangeLight ();
	}

	void ChangeLight()
	{
		if (Input.GetButton (controller.playerCode + "Jump")) 
		{
			mLight.color = Color.yellow;
		}
		else if (Input.GetButton (controller.playerCode + "Fire2")) 
		{
			mLight.color = Color.red;
		}
		else if (Input.GetButton (controller.playerCode + "Fire3")) 
		{
			mLight.color = Color.blue;
		}
	}
}
