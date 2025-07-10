using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {

	private List<Material> materials = new();

	public Material outlineMat;
	public MeshRenderer meshRenderer;


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
		//löst das Event aus
		//Invoke = ausführen/aufrufen
		interacted.Invoke();
	}

	public void SetHighlight(bool active) {
		if(active) {
			meshRenderer.GetMaterials(materials);
			materials.Add(outlineMat);
			meshRenderer.SetMaterials(materials);
		} else {
			meshRenderer.GetMaterials(materials);
			materials.RemoveAt(materials.Count - 1); //last material
			meshRenderer.SetMaterials(materials);
		}

		//mit 1 Material
		//meshRenderer.material = ...;

		//Wert im Material setzen
		outlineMat.SetFloat("_Thickness", 0.05f);
	}
}
