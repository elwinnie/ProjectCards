using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Loading : MonoBehaviour {
	public string nameLevel;
	public GameObject loadObject;
	public string animName;

	AsyncOperation async;
	//float loadProgress;

	void Start() {
		StartCoroutine(launchLevel (nameLevel));
	}

	void Update() {
		if (loadObject.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName (animName))
			async.allowSceneActivation = true;
	}

	IEnumerator launchLevel(string nLevel) {
		async = Application.LoadLevelAsync (nLevel);
		async.allowSceneActivation = false;
		
		while (!async.isDone) {
			//loadProgress = async.progress;
			yield return true;
		}
	}
}
