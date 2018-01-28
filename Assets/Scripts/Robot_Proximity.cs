using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class Robot_Proximity : MonoBehaviour {

	[SerializeField] private GameObject robotP1;
	[SerializeField] private GameObject robotP2;



	private PlayerController p1Controller;

	private PlayerController p2Controller;

	[SerializeField] private LineRenderer line;

	private bool vibrate = false;

	[SerializeField] private AudioSource mSource;

	// Use this for initialization
	void Start () {
		p1Controller = robotP1.GetComponent<PlayerController> ();

		p2Controller = robotP2.GetComponent<PlayerController> ();


	}
	
	// Update is called once per frame
	void Update () {

		if (CheckDistance ()) {
			line.gameObject.SetActive (true);
			vibrate = true;
			if (!mSource.isPlaying) {
				mSource.Play ();
			}

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
			ColorLight mixedColor = ColorUtils.CombineColors (p1Controller.personalColor, p2Controller.personalColor);

			p1Controller.updateCurrentColor (mixedColor);
			p2Controller.updateCurrentColor (mixedColor);

			EnergyBattery.instance.SetOverheat (true);



			return true;
		} else 
		{


			p1Controller.updateCurrentColor (p1Controller.personalColor);
			p2Controller.updateCurrentColor (p2Controller.personalColor);




			EnergyBattery.instance.SetOverheat (false);

			if (mSource.isPlaying)
			{
				mSource.Stop ();
			}


			return false;
		}
	}

	void SetLine ()
	{
		line.SetPosition (0, robotP1.transform.position);
		line.SetPosition (1, robotP2.transform.position);
	}
	
}
