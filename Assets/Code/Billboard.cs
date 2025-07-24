using UnityEngine;

public class Billboard : MonoBehaviour {


	private Camera camera;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		camera = Camera.main;
	}

	// Update is called once per frame
	void Update() {
		transform.rotation = camera.transform.rotation;
	}
}
