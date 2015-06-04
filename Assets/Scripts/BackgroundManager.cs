using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BackgroundManager : MonoBehaviour {
	//Массив с изображениями.
	public Sprite[] backgrounds;
	public GameObject initiallyOpen;

	void Awake() {
		RandomBackground (initiallyOpen, backgrounds);
	}

	void RandomBackground(GameObject mainObject, Sprite[] arrayBackgrounds) {
		int choice = Random.Range (0, arrayBackgrounds.Length);
		
		mainObject.GetComponent<Image>().sprite = backgrounds[choice];
	}
}
