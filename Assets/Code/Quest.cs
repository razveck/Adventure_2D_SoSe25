using UnityEngine;
using UnityEngine.Events;

public class Quest : MonoBehaviour {
	public string objective;
	public UnityEvent onStarted;
	public UnityEvent onCompleted;
}
