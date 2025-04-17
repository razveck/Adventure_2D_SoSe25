using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

	Transform referenceCamera;
	InputAction moveAction;
	public Interactable currentInteractable;

	public PlayerInput input;
	public CharacterController controller;
	public CameraManager cameraManager;

	public float speed = 7f;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		moveAction = input.currentActionMap.FindAction("Move");
		referenceCamera = cameraManager.activeCamera.transform;
	}

	// Update is called once per frame
	void Update() {
		if(moveAction.WasPressedThisFrame()) {
			referenceCamera = cameraManager.activeCamera.transform;
		}


		Vector2 moveInput = moveAction.ReadValue<Vector2>();
		Vector3 direction = new(moveInput.x, 0f, moveInput.y);

		Vector3 move = referenceCamera.TransformDirection(direction);
		move.y = 0f;
		move.Normalize();

		if(move != Vector3.zero) {
			transform.forward = Vector3.Slerp(transform.forward, move, 0.1f);
			
		}

		controller.Move(move * speed * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other) {
		Interactable interactable = other.GetComponent<Interactable>(); //auf 'other' nach 'Interactable' suchen
		//wenn 'other' kein 'Interactable' hat, wird die Variabel null
		if(interactable != null)
			currentInteractable = interactable; //wir merken uns dann den Script, für später ;)
	}

	private void OnTriggerExit(Collider other) {
		Interactable interactable = other.GetComponent<Interactable>(); //auf 'other' nach 'Interactable' suchen
		//wenn 'other' kein 'Interactable' hat, wird die Variabel null
		if(interactable != null)
			currentInteractable = null; //wir merken uns dann den Script, für später ;)
	}
}
