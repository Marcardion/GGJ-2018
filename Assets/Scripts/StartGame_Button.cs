using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartGame_Button : MonoBehaviour {

	[SerializeField] private GameObject p1Flag;
	[SerializeField] private GameObject p2Flag;

	[SerializeField] private AudioClip p1Clip;
	[SerializeField] private AudioClip p2Clip;

	private bool ready = true;

	[SerializeField] private string pressButton = "Fire1";

	[SerializeField] private Animator radioAnimator;

	[SerializeField] private AudioClip brokenRadioClip;

	[SerializeField] private Image black;

	// Use this for initialization
	void Start () {
		StartCoroutine ("FadeIn");
	}
	
	// Update is called once per frame
	void Update () {
		CheckOk ();
	}

	void CheckOk()
	{
		if (Input.GetButtonDown ("P1" + pressButton) && !p1Flag.activeSelf) 
		{
			p1Flag.SetActive (true);
			SoundManager.instance.PlaySingle (p1Clip, 0);
		}

		if (Input.GetButtonDown ("P2" + pressButton) && !p2Flag.activeSelf) 
		{
			p2Flag.SetActive (true);
			SoundManager.instance.PlaySingle (p2Clip, 0);
		}
			
		if (p1Flag.activeSelf && p2Flag.activeSelf) 
		{
			if(ready)
			{
				StartCoroutine (StartGame ());
				ready = false;
			}
		}
			
	}

	IEnumerator StartGame()
	{
		StartCoroutine ("FadeOut");
		radioAnimator.SetBool ("Stop", true);
		SoundManager.instance.StopMusic ();
		SoundManager.instance.PlaySingle ( brokenRadioClip, 3);
		yield return new WaitForSeconds (2f);

		SoundManager.instance.StopPlay (3);
		GetComponent<LoadScene> ().Load ();
	}



	public IEnumerator FadeOut()
	{
		yield return new WaitForSeconds (1f);

		float i = 0;

		while (i < 1) 
		{
			black.color = new Color (black.color.r, black.color.g, black.color.b, i);
			i = i + Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}
	}

	public IEnumerator FadeIn()
	{
		
		float i = 1;

		while (i > 0) 
		{
			if (black != null) {
				black.color = new Color (black.color.r, black.color.g, black.color.b, i);
			}

			i = i - Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}
	}
}
