using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogScreen : MonoBehaviour {

	private Coroutine typewriter;
	private DialogLine currentDialog;

	public TextMeshProUGUI charNameText;
	public TextMeshProUGUI dialogText;
	public Image portraitImage;
	public Button[] choiceButtons;
	public Button continueButton;

	public PlayerInput input;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
	}

	public void ShowDialog(DialogLine dialog) {
		currentDialog = dialog;

		charNameText.text = dialog.characterName;
		dialogText.text = dialog.text;
		portraitImage.sprite = dialog.characterPortrait;

		for(int i = 0; i < choiceButtons.Length; i++) {
			if(i < dialog.choices.Length) {
				choiceButtons[i].gameObject.SetActive(true);
				choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = dialog.choices[i].name;
			} else {
				choiceButtons[i].gameObject.SetActive(false);
			}
		}

		if(dialog.choices.Length == 0)
			EventSystem.current.SetSelectedGameObject(continueButton.gameObject);
		else
			EventSystem.current.SetSelectedGameObject(choiceButtons[0].gameObject);

		continueButton.gameObject.SetActive(dialog.choices.Length == 0);


		input.SwitchCurrentActionMap("UI");
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;

		dialog.onShown.Invoke();

		gameObject.SetActive(true);
		//StopAllCoroutines();
		if(typewriter != null)
			StopCoroutine(typewriter);

		typewriter = StartCoroutine(TypewriterCoroutine());
	}

	IEnumerator TypewriterCoroutine(){
		//Dialog Beispiel 123

		//nicht-optimale Lösung
		//string finalText = dialogText.text;
		//for(int i = 0; i < finalText.Length + 1; i++) {
		//	dialogText.text = finalText.Substring(0, i);
		//	yield return new WaitForSeconds(0.05f);
		//}
		
		//optimale Lösung
		dialogText.maxVisibleCharacters = 0;
		for(int i = 0; i < dialogText.text.Length; i++) {
			dialogText.maxVisibleCharacters++;
			yield return new WaitForSeconds(0.05f);
		}

		dialogText.maxVisibleCharacters = 999999999;
	}

	public void EndDialog() {
		gameObject.SetActive(false);
		input.SwitchCurrentActionMap("Player");

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void SelectChoice(int index) {
		currentDialog.choices[index].onChosen.Invoke();
		ShowDialog(currentDialog.choices[index].nextLine);
	}

}
