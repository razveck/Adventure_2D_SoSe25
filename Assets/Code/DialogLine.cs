using UnityEngine;
using UnityEngine.Events;

public class DialogLine : MonoBehaviour {
	public string text;
	public DialogChoice[] choices;
	public string characterName;
	public Sprite characterPortrait;
	public UnityEvent onShown;
}
