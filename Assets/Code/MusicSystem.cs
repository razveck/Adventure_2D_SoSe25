using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class MusicSystem : MonoBehaviour {

	//static var wird für die Laufzeit des Spiels behalten
	public static EventInstance music;
	private static bool musicStarted;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		if(!musicStarted) {
			music = RuntimeManager.CreateInstance("event:/Music/OST_CozyGame");
			music.start();
			musicStarted = true;
		}
		music.setParameterByNameWithLabel("Scene", "Menu");
	}
}
