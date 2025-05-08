using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogScreen : MonoBehaviour {

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

		gameObject.SetActive(true);
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
