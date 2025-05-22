using FMODUnity;
using UnityEngine;

public class Footsteps : MonoBehaviour {

	public EventReference eventRef;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	public void PlayFootstep() {
		//alternative zu EventEmitter
		RuntimeManager.PlayOneShot("event:/SFX/Footsteps/SFX_Footsteps", transform.position);
		//RuntimeManager.PlayOneShot(eventRef);
	}
}
