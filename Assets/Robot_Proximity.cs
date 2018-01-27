using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class Robot_Proximity : MonoBehaviour {

	[SerializeField] private GameObject robotP1;
	[SerializeField] private GameObject robotP2;

	[SerializeField] private LineRenderer line;

	private bool vibrate = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (CheckDistance ()) {
			line.gameObject.SetActive (true);
			vibrate = true;
			SetLine ();
		} else 
		{
			if (vibrate) 
			{
				vibrate = false;
				GamePad.SetVibration ((PlayerIndex)0, 0, 0);
				GamePad.SetVibration ((PlayerIndex)1, 0, 0);
			}
			line.gameObject.SetActive (false);
		}
		
	}

	void OnDisable()
	{
		GamePad.SetVibration ((PlayerIndex)0, 0, 0);
		GamePad.SetVibration ((PlayerIndex)1, 0, 0);
	}

	void FixedUpdate()
	{
		if (vibrate) {
			GamePad.SetVibration ((PlayerIndex)0, 0.5f, 0.5f);
			GamePad.SetVibration ((PlayerIndex)1, 0.5f, 0.5f);
		} 
	}

	bool CheckDistance ()
	{
		if (Vector3.Distance (robotP1.transform.position, robotP2.transform.position) <= 5) {
			return true;
		} else 
		{
			return false;
		}
	}

	void SetLine ()
	{
		line.SetPosition (0, robotP1.transform.position);
		line.SetPosition (1, robotP2.transform.position);
	}
	
}
