using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeColor : MonoBehaviour {


	[SerializeField] private float countdownTime = 10f;

	[SerializeField] private List<ColorLight> colors;

	[SerializeField] private Light mLight;


	[SerializeField] private float currentTime = 0f;

	// Use this for initialization
	void Start () {
		
		currentTime = countdownTime;
	}
	
	// Update is called once per frame
	void Update () {
		
			currentTime -= Time.deltaTime;

			if (currentTime <= 0) {
				RandomizeObjColor ();
				currentTime = countdownTime;
			}

		 
	}

	private void RandomizeObjColor() {
		int index = Random.Range (0, colors.Count);	


		mLight.color = ColorUtils.GetColor (colors [index]);



	}


}
