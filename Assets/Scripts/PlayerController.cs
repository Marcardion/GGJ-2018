using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { Normal, Damaged, Dead }

public class PlayerController : MonoBehaviour {

	public string playerCode;

	private State currentState; 

	// Use this for initialization
	void Start () {
		currentState = State.Normal;
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
}
