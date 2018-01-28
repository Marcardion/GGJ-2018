using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int activeChests = 0;

	public static GameManager instance;

	[SerializeField] private Text mText;

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
			StartCoroutine (GameOver ());
		}
	}

	IEnumerator GameOver()
	{
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene ("Main Menu");
	}
}
