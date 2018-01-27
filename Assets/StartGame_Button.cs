using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame_Button : MonoBehaviour {

	[SerializeField] private GameObject p1Flag;
	[SerializeField] private GameObject p2Flag;

	private bool ready = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckOk ();
	}

	void CheckOk()
	{
		if (Input.GetButtonDown ("P1Fire1") && !p1Flag.activeSelf) 
		{
			p1Flag.SetActive (true);
		}

		if (Input.GetButtonDown ("P2Fire1") && !p2Flag.activeSelf) 
		{
			p2Flag.SetActive (true);
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
