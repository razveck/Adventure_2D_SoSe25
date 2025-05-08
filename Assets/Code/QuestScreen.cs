using TMPro;
using UnityEngine;

public class QuestScreen : MonoBehaviour {

	public TextMeshProUGUI objectiveText;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {

	}

	public void StartQuest(Quest quest){
		objectiveText.text = quest.objective;
		quest.onStarted.Invoke();

		gameObject.SetActive(true);
	}

	public void EndQuest(Quest quest){
		quest.onCompleted.Invoke();

		gameObject.SetActive(false);
	}

}
