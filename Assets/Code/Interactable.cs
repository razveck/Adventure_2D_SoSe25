using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {

	//C# event
	//public event System.Action interacted;
	//Unity event
	public UnityEvent interacted;



	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		//anwendungsbeispiel
		//interacted += OnInteract;
		//interacted.AddListener(OnInteract);
	}

	public void Interact() {
		//l�st das Event aus
		//Invoke = ausf�hren/aufrufen
		interacted.Invoke();
	}
}
