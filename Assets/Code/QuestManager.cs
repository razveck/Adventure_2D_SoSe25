using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QuestManager : MonoBehaviour {

	public Interactable mario;
	public Interactable luigi;
	public GameObject dialogScreen;
	public GameObject questScreen;
	public TextMeshProUGUI questObjective;

	public DialogLine dialogQuest1;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	IEnumerator Start() {
		questScreen.SetActive(true);
		questObjective.text = "Talk to Mario";

		//yield return WaitForNPC(mario);
		yield return WaitForDialog(dialogQuest1);
		luigi.gameObject.SetActive(true);
		yield return new WaitWhile(() => dialogScreen.activeSelf);

		questObjective.text = "Talk to Luigi";

		yield return WaitForNPC(luigi);

		Debug.Log("Quest Done");

		luigi.GetComponent<NPC>().nextLine = dialogQuest1;
	}

	IEnumerator WaitForNPC(Interactable interactable){
		bool talked = false;

		//anonyme Funktion in eine Variabel speichern (wiederverwenden)
		UnityAction action = () => {
			talked = true;
		};

		interactable.interacted.AddListener(action);
		yield return new WaitUntil(() => talked);
		interactable.interacted.RemoveListener(action);
	}

	IEnumerator WaitForDialog(DialogLine dialog){
		bool shown = false;

		//anonyme Funktion in eine Variabel speichern (wiederverwenden)
		UnityAction action = () => {
			shown = true;
		};

		dialog.onShown.AddListener(action);
		yield return new WaitUntil(() => shown);
		dialog.onShown.RemoveListener(action);
	}

	IEnumerator WaitForItems(Interactable[] items){
		int counter = 0;

		//anonyme Funktion in eine Variabel speichern (wiederverwenden)
		UnityAction action = () => {
			counter++;
		};
		for(int i = 0; i < items.Length; i++) {
			items[i].interacted.AddListener(action);
		}
		yield return new WaitUntil(() => counter == 3);

		for(int i = 0; i < items.Length; i++) {
			items[i].interacted.RemoveListener(action);
		}
	}

	/*
	// Update is called once per frame
	void Update() {
		if(Input.GetKeyDown(KeyCode.Space)) {
			//Unity Editor hängt
			//for(int i = 0; i < 100000000; i++) {
			//	Debug.Log(i);
			//}

			StartCoroutine(ExampleCoroutine());
		}

		if(Input.GetKeyDown(KeyCode.X)) {
			StopAllCoroutines();
			//StopCoroutine();
		}
	}

	private IEnumerator ExampleCoroutine() {
		//Unity Editor hängt NICHT
		for(int i = 0; i < 100000000; i++) {
			yield return new WaitForEndOfFrame(); //wait for next frame implizit
			Debug.Log(i);
		}
	}

	*/
}
