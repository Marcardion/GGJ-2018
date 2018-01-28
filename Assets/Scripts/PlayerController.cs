using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { Normal, Damaged, Dead }

public class PlayerController : MonoBehaviour {

	public string playerCode;

	private State currentState; 

	public ColorLight currentColor;

	public ColorLight personalColor;

	[SerializeField] private Light mLight;



	[HideInInspector] public Animator mAnimator;

	// Use this for initialization
	void Start () {
		currentState = State.Normal;
		updateCurrentColor (ColorLight.Blue);
		personalColor = ColorLight.Blue;

		mAnimator = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool isNormal(){
		return currentState == State.Normal;
	}

	public bool isTakingDamage(){
		return currentState == State.Damaged;
	}


	public bool isDead(){
		return currentState == State.Dead;
	}


	public void updatePersonalColor(ColorLight colorLight){
		
		updateCurrentColor (colorLight);
		personalColor = colorLight;

	}

	public void updateCurrentColor(ColorLight colorLight){
		mLight.color = ColorUtils.GetColor (colorLight);
		currentColor = colorLight;
	}

	public void EnableIsInteracting(){
		Debug.Log ("IsInteracting");
		mAnimator.SetBool ("IsInteracting", true);
	}

	public void DisableIsInteracting(){
		mAnimator.SetBool ("IsInteracting", false);
	}
}
