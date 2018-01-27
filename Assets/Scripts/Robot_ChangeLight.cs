using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorLight { Blue, Yellow, Red, Green, Orange, Purple };

public class Robot_ChangeLight : MonoBehaviour {

	public ColorLight mColor;

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
			mColor = ColorLight.Yellow;
		}
		else if (Input.GetButton (controller.playerCode + "Fire2")) 
		{
			mLight.color = Color.red;
			mColor = ColorLight.Red;
		}
		else if (Input.GetButton (controller.playerCode + "Fire3")) 
		{
			mLight.color = Color.blue;
			mColor = ColorLight.Blue;
		}
	}
}
