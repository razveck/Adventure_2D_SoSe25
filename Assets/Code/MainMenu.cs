using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Button startBtn;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		startBtn.onClick.AddListener(() => {
			SceneManager.LoadScene(1);
			MusicSystem.music.setParameterByNameWithLabel("Scene", "Level");

		}
		);
	}
}
