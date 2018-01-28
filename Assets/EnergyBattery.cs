using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnergyBattery : MonoBehaviour {

	private Slider mSlider;

	[SerializeField] private float maxEnergy;

	private bool overHeated = false;

	public static EnergyBattery instance;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {

		mSlider = GetComponent<Slider> ();
		mSlider.maxValue = maxEnergy;
		mSlider.value = maxEnergy;
	}
	
	// Update is called once per frame
	void Update () {
		if (overHeated) 
		{
			DecreaseEnergy (Time.deltaTime*3);	
		} else 
		{
			DecreaseEnergy (Time.deltaTime);
		}

		if (mSlider.value == 0) 
		{
			//Game Over

			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}

	void DecreaseEnergy(float energy)
	{
		mSlider.value = mSlider.value - energy;
	}

	public void SetOverheat(bool mode)
	{
		overHeated = mode;
	}
}
