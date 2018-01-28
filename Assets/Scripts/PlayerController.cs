using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { Normal, Damaged, Falling, Dead }

public class PlayerController : MonoBehaviour {

	public string playerCode;

	public State currentState; 

	public ColorLight currentColor;

	public ColorLight personalColor;

	[SerializeField] private Light mLight;

	[SerializeField] private LineRenderer effect;

	[HideInInspector] public Animator mAnimator;


	[SerializeField] private AudioClip[] fallingSfxs;

	private Vector3 initialPosition;

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		currentState = State.Normal;
		updateCurrentColor (ColorLight.Blue);
		personalColor = ColorLight.Blue;

		mAnimator = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		checkIsFalling ();
		checkFallRespawn ();
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
		effect.startColor = ColorUtils.GetColor (colorLight);
		effect.endColor = ColorUtils.GetColor (colorLight);
	}

	public void EnableIsInteracting(Vector3 position){
		Debug.Log ("IsInteracting");
		mAnimator.SetBool ("IsInteracting", true);
		effect.SetPosition (0, transform.position);
		effect.SetPosition (1, position);

	}

	public void DisableIsInteracting(){
		mAnimator.SetBool ("IsInteracting", false);
		effect.SetPosition (0, transform.position);
		effect.SetPosition (1, transform.position);
	}

	private void checkIsFalling(){
		if (transform.position.y < -2f && currentState != State.Falling ){
			currentState = State.Falling;
			if (!SoundManager.instance.IsChannelPlaying (1)) {
				SoundManager.instance.RandomizeSfx (1, fallingSfxs);
			} else {
				SoundManager.instance.RandomizeSfx (2, fallingSfxs);
			}

		}
	}

	private void checkFallRespawn(){
		
		if (transform.position.y < -15) {
			transform.position = initialPosition;
			currentState = State.Normal;
			if (SoundManager.instance.IsChannelPlaying (1)) {
				SoundManager.instance.StopPlay (1);
			} else {
				SoundManager.instance.StopPlay (2);
			}
		}
	}
}
