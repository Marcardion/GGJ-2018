using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour {

	public ColorLight currentLight;



	[SerializeField] private float life =  6f;

	private bool activating = false;

	public bool enabled = true;

	// Use this for initialization
	void Start () {
		currentLight = ColorLight.Blue;
	}
	
	// Update is called once per frame
	void Update () {
		if (activating) {
			life -= Time.deltaTime;

			if (life <= 0){
				updateLightColor (ColorLight.None);
				enabled = false;
				//Destroy (this.gameObject);
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
				Debug.Log ("clicking button A");

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
		activating = true;
		controller.EnableIsInteracting ();
		controller.gameObject.transform.LookAt (transform.position);
	}

	private void DisableActivate(PlayerController controller){
		activating = false;
		controller.DisableIsInteracting ();
	}

}
