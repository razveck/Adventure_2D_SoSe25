using UnityEngine;

public class NPC : MonoBehaviour {
	
	public DialogLine nextLine;
	public DialogScreen dialogScreen;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {

	}

	public void StartDialog() {
		//nextLine an DialogScreen �bertragen
		dialogScreen.ShowDialog(nextLine);
	}
}
