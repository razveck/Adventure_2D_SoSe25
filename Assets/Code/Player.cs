using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

	Transform referenceCamera;
	InputAction moveAction;
	InputAction interactAction;
	public Interactable currentInteractable;

	public PlayerInput input;
	public CharacterController controller;
	public CameraManager cameraManager;

	public float speed = 7f;
	public float gravity = 9.81f;
	public float yVelocity;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		moveAction = input.currentActionMap.FindAction("Move");
		interactAction = input.currentActionMap.FindAction("Interact");
		//C# events
		interactAction.performed += OnInteracted;
		

		referenceCamera = cameraManager.activeCamera.transform;
	}

	private void OnDestroy() {
		interactAction.performed -= OnInteracted;
	}

	private void OnInteracted(InputAction.CallbackContext obj) {
		if(currentInteractable != null){
			currentInteractable.Interact();
		}
	}

	// Update is called once per frame
	void Update() {
		if(moveAction.WasPressedThisFrame()) {
			referenceCamera = cameraManager.activeCamera.transform;
		}


		Vector2 moveInput = moveAction.ReadValue<Vector2>();

		
		Vector3 forward = Vector3.ProjectOnPlane(referenceCamera.forward, Vector3.up).normalized;
		Vector3 right = Vector3.ProjectOnPlane(referenceCamera.right, Vector3.up).normalized;
		//wie viel auf right + wie viel auf forward
		Vector3 move = right * moveInput.x + forward * moveInput.y;
		

		if(move != Vector3.zero) {
			transform.forward = Vector3.Slerp(transform.forward, move, 0.1f);
			
		}

		move*= speed;

		yVelocity -= gravity * Time.deltaTime;
		move.y = yVelocity;

		if(controller.Move(move * Time.deltaTime) == CollisionFlags.Below)
			yVelocity = -5;

		//if(controller.isGrounded)
		//	yVelocity = 0;
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

	//statt OnCollisionEnter
	private void OnControllerColliderHit(ControllerColliderHit hit) {
		
	}
}
