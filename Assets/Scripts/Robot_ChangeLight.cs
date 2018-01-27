using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorLight { None, Blue, Yellow, Red, Green, Orange, Purple, Cyan, Magenta };

public class Robot_ChangeLight : MonoBehaviour {

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
			controller.updateCurrentColor (ColorLight.Yellow);
		}
		else if (Input.GetButton (controller.playerCode + "Fire2")) 
		{
			controller.updateCurrentColor (ColorLight.Red);

		}
		else if (Input.GetButton (controller.playerCode + "Fire3")) 
		{
			controller.updateCurrentColor (ColorLight.Blue);

		}
	}
}
