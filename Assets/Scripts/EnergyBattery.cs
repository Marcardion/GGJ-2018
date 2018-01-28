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

	public bool active = true;

	[SerializeField] private AudioClip deathSound;

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
		if (active) {
			if (overHeated) {
				DecreaseEnergy (Time.deltaTime * 3);	
			} else {
				DecreaseEnergy (Time.deltaTime);
			}

		}
		if (mSlider.value == 0) 
		{
			//Game Over
			if (active) 
			{
				StartCoroutine (GameOver ());
				active = false;
			}

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

	public void AddEnergy(float energy)
	{
		mSlider.value = mSlider.value + energy;
	}

	IEnumerator GameOver()
	{
		KillPlayers ();
		SoundManager.instance.PlaySingle (deathSound, 0);
		yield return new WaitForSeconds (1f);
		StartCoroutine(GameManager.instance.FadeOut ());
		yield return new WaitForSeconds (3f);

		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	void KillPlayers()
	{
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");

		foreach (GameObject player in players) 
		{
			player.GetComponent<PlayerController> ().currentState = State.Dead;
			player.GetComponent<PlayerController> ().mAnimator.SetTrigger ("Dead");
		}
	}
}
