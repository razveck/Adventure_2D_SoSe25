using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public Button resume;
	public Button options;
	public Button exit;
	public GameObject pauseMenu;
	public GameObject optionsMenu;

	public GameObject dialogScreen;

	public PlayerInput input;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	IEnumerator Start() {
		exit.onClick.AddListener(() => {
			input.actions.FindActionMap("Player").FindAction("Pause").performed -= OnPaused;
			input.actions.FindActionMap("UI").FindAction("Pause").performed -= OnPaused;
			SceneManager.LoadScene(0);

		});


		input.actions.FindActionMap("Player").FindAction("Pause").performed += OnPaused;
		input.actions.FindActionMap("UI").FindAction("Pause").performed += OnPaused;

		//wenn beide Actions ausgelöst werden, muss man 1 frame warten + eine map ausschalten
		yield return null; //warten bis zum nächstmöglichen Zeitpunkt (meistens next frame)
		input.actions.FindActionMap("UI").Disable();
	}

	private void OnDisable() {
		if(input != null) {
			input.actions.FindActionMap("Player").FindAction("Pause").performed -= OnPaused;
			input.actions.FindActionMap("UI").FindAction("Pause").performed -= OnPaused;
		}
	}

	private void OnPaused(InputAction.CallbackContext obj) {
		if(Time.timeScale == 0f) {
			Time.timeScale = 1f;
			pauseMenu.SetActive(false);

			//wenn DialogScreen activ ist, wollen wir NICHT den Cursor ausblenden, usw.
			if(!dialogScreen.activeSelf) {
				input.SwitchCurrentActionMap("Player");
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
			}

		} else {
			Time.timeScale = 0f;
			pauseMenu.SetActive(true);
			optionsMenu.SetActive(false);

			input.SwitchCurrentActionMap("UI");
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
