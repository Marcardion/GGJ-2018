using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour {

	public ColorLight currentLight;

	[SerializeField] private Light mLight;

	// Use this for initialization
	void Start () {
		currentLight = ColorLight.Blue;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateLightColor(ColorLight colorLight){
		Color color = ColorUtils.GetColor (colorLight);
		mLight.color = color;
		currentLight = colorLight;
	}
}
