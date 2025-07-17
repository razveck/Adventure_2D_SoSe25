using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	public GameObject optionsMenu;
	public Slider masterSlider;
	public Button exit;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		exit.onClick.AddListener(() => optionsMenu.SetActive(false));

		masterSlider.onValueChanged.AddListener(OnMasterSlider);
		masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.5f);

		//bool bla = false;
		//PlayerPrefs.SetString("mybool", bla.ToString());

		//volume aus Fmod lesen
		//Debug.Log(RuntimeManager.GetBus("bus:/").getVolume(out float volume));
	}

	void OnMasterSlider(float value){


		//RuntimeManager.GetVCA("vca:/MyVCA");
		RuntimeManager.GetBus("bus:/").setVolume(value);
		//PlayerPrefs ist wie eine Saved Variable
		PlayerPrefs.SetFloat("MasterVolume", value);
		
	}


}
