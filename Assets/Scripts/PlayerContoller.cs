using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour {

	public GameObject avatarObject;
	public Sprite[] avatars;
	public Text nameField;

	private int count = 0;
	private string playerName;
	private Sprite avatarChoice;

	void Awake() {
		avatarObject.GetComponent<Image> ().sprite = avatars [count];
		playerName = nameField.text;
		avatarChoice = avatars [count];
	}

	void FixedUpdate() {
		avatarObject.GetComponent<Image> ().sprite = avatars [count];
		playerName = nameField.text;
		avatarChoice = avatars [count];
	}

	public void leftButton() {
		if (avatars == null)
			return;
		
		
		if (count < 1) {
			count = avatars.Length;
		}
		count--;
	}
	
	public void rightButton() {
		if (avatars == null)
			return;
		
		count++;
		if (count > avatars.Length - 1) {
			count = 0;
		}
	}
}
