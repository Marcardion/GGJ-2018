using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int activeChests = 0;

	public static GameManager instance;

	[SerializeField] private Text mText;

	[SerializeField] private SpriteRenderer black;

	[SerializeField] private string nextLevel;

	void Awake ()
	{
		if (instance != null) {
			Destroy (this.gameObject);
		} else 
		{
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {

		mText.text = activeChests.ToString ();
		StartCoroutine (FadeIn ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChestEnded()
	{
		activeChests--;
		mText.text = activeChests.ToString ();
		CheckGameOver ();
	}

	public void UpdateText()
	{
		mText.text = activeChests.ToString ();
	}

	void CheckGameOver()
	{
		if (activeChests <= 0) 
		{
			Debug.Log ("Game Over");
			EnergyBattery.instance.active = false;
			DeactivatePlayers ();
			StartCoroutine (FadeOut ());
			StartCoroutine (GameOver ());
		}
	}

	IEnumerator GameOver()
	{
		yield return new WaitForSeconds (3f);
		SceneManager.LoadScene (nextLevel);
	}

	void DeactivatePlayers()
	{
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");

		foreach (GameObject player in players) 
		{
			player.GetComponent<PlayerController> ().currentState = State.Dead;
		}
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
			black.color = new Color (black.color.r, black.color.g, black.color.b, i);
			i = i - Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}
	}
}
