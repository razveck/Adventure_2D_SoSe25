using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public CinemachineCamera activeCamera;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {

	}

	public void ChangeCamera(CinemachineCamera newCamera){
		activeCamera.gameObject.SetActive(false); //alte Camera ausschalten

		newCamera.gameObject.SetActive(true); //neue Camera einschalten
		activeCamera = newCamera;
	}
}
