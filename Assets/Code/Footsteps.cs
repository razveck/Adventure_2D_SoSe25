using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class Footsteps : MonoBehaviour {

	private EventInstance eventInstance;

	public EventReference eventRef;
	public LayerMask groundLayer;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		eventInstance = RuntimeManager.CreateInstance(eventRef);
		eventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform));
		eventInstance.setParameterByNameWithLabel("Untergründe", "Leaves");
	}

	public void PlayFootstep() {
		//alternative zu EventEmitter
		//RuntimeManager.PlayOneShot("event:/SFX/Footsteps/SFX_Footsteps", transform.position);
		//RuntimeManager.PlayOneShot(eventRef);

		if(Physics.Raycast(transform.position + new Vector3(0, 10, 0), Vector3.down, out RaycastHit hit, 20f, groundLayer)) {
			eventInstance.setParameterByNameWithLabel("Untergründe", hit.collider.tag);
		} else {
			eventInstance.setParameterByNameWithLabel("Untergründe", "Leaves");
		}

		eventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform));
		eventInstance.start();
	}
}
