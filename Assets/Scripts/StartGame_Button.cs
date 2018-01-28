using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame_Button : MonoBehaviour {

	[SerializeField] private GameObject p1Flag;
	[SerializeField] private GameObject p2Flag;

	[SerializeField] private AudioClip p1Clip;
	[SerializeField] private AudioClip p2Clip;

	private bool ready = true;

	[SerializeField] private string pressButton = "Fire1";

	// Use this for initialization
	void Start () {
		
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
		yield return new WaitForSeconds (1f);
		GetComponent<LoadScene> ().Load ();
	}
}
