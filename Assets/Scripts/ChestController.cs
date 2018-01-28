using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour {

	public ColorLight currentLight;

	private AudioSource mAudio;

	[SerializeField] private float life =  6f;

	[SerializeField] private AudioClip chestEnd;

	private bool activating = false;

	public bool enabled = true;

	private bool p1IsInteracting = false;

	private bool p2IsInteracting = false;

	// Use this for initialization
	void Start () {
		enabled = true;
		currentLight = ColorLight.Blue;
		GameManager.instance.activeChests++;
		GameManager.instance.UpdateText ();

		mAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (activating) {
			life -= Time.deltaTime;
			if (p1IsInteracting && p2IsInteracting) {
				life -= Time.deltaTime * 2;
			} 


			if (life <= 0){
				
				if (enabled) {
					updateLightColor (ColorLight.None);
					EnergyBattery.instance.AddEnergy (10f);
					GameManager.instance.ChestEnded ();
					SoundManager.instance.PlaySingle (chestEnd, 0);
					enabled = false;
				}
					
			}
		}
	}

	public void updateLightColor(ColorLight colorLight){
		Color color = ColorUtils.GetColor (colorLight);

		GetComponent<Renderer> ().material.color = color;
		currentLight = colorLight;
	}

	void OnTriggerStay( Collider other){

		if (other.tag == "Player") {
			PlayerController controller = other.gameObject.GetComponent<PlayerController> ();
			if (Input.GetButton (controller.playerCode + "Fire1")) {
				

				if (currentLight == controller.currentColor) {
					EnableActivate (controller);
				} else {
					DisableActivate (controller);
				}
	
			} else {
				DisableActivate (controller);
			}
		}
	}

	void OnTriggerExit( Collider other){
		
		if (other.tag == "Player") {
			PlayerController controller = other.gameObject.GetComponent<PlayerController> ();
			DisableActivate (controller);

		}
	}

	private void EnableActivate(PlayerController controller){

		if (controller.playerCode == "P1") {
			p1IsInteracting = true;
		} else {
			p2IsInteracting = true;
		}

		activating = true;
		controller.EnableIsInteracting (transform.position);
		controller.gameObject.transform.LookAt (transform.position);

		if (!mAudio.isPlaying) 
		{
			mAudio.Play ();
		}
	}

	private void DisableActivate(PlayerController controller){

		Debug.Log ("Disable Acitvate " + controller.playerCode);
		if (controller.playerCode == "P1") {
			p1IsInteracting = false;
		} else {
			p2IsInteracting = false;
		}

		if (!p1IsInteracting && !p2IsInteracting){
			activating = false;
		}

		if (mAudio.isPlaying) 
		{
			mAudio.Stop ();
		}

		controller.DisableIsInteracting ();
	}

}
