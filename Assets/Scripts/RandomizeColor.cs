using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeColor : MonoBehaviour {

	private ChestController controller;

	[SerializeField] private float countdownTime = 10f;

	[SerializeField] private List<ColorLight> colors;

	[SerializeField] private float currentTime = 0f;

	// Use this for initialization
	void Start () {
		controller = GetComponent<ChestController> ();
		currentTime = countdownTime;
		RandomizeObjColor ();
	}
	
	// Update is called once per frame
	void Update () {

		if (controller.enabled) {

			currentTime -= Time.deltaTime;

			if (currentTime <= 0) {
				RandomizeObjColor ();
				currentTime = countdownTime;
			}
		}
		 
	}

	private void RandomizeObjColor() {
		int index = Random.Range (0, colors.Count);	
		controller.updateLightColor (colors [index]);


	}


}
