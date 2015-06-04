using UnityEngine;
using System.Collections;

public class SoundPlay : MonoBehaviour {

	public void PlayOnButton(AudioClip sound) {
		if(sound == null)
			return;
		gameObject.GetComponent<AudioSource>().clip = sound;
		gameObject.GetComponent<AudioSource>().Play();
	}
}
