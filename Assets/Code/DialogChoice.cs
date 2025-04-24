using UnityEngine;
using UnityEngine.Events;

[System.Serializable] //zeigt Unity, dass die Klasse gespeichert werden darf
public class DialogChoice {
	public string name;
	public DialogLine nextLine;
	public UnityEvent onChosen;
}
