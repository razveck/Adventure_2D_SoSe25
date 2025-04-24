using UnityEngine;

public class NPC : MonoBehaviour {
	
	public DialogLine nextLine;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {

	}

	public void StartDialog() {
		Debug.Log("Hallo");
		//nextLine an DialogScreen übertragen
	}
}
