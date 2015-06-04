using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UIController : MonoBehaviour {
	//Массив с изображениями.
	public Sprite[] backgrounds;

	//Главный экран и массив с второстепенными.
	public GameObject instantiateScreen;
	public GameObject[] UIScreens;

	void Awake() {
		instantiateScreen.SetActive (true);
		for (int i = 0; i < UIScreens.Length; i++)
			UIScreens[i].SetActive(false);
		RandomBackground (instantiateScreen, backgrounds);
	}

	//Функция отвечающая за сменный фон. Принимает игровой объект в котом изменяется фон и массив с изображениям.
	void RandomBackground(GameObject mainObject, Sprite[] arrayBackgrounds) {
		int choice = Random.Range (0, arrayBackgrounds.Length);

		mainObject.GetComponent<Image>().sprite = backgrounds[choice];
	}

	//Функция отвечает за смену экранов.
	public void ChangeScreen(GameObject changeScreen) {
		if (changeScreen != instantiateScreen) {
			instantiateScreen.SetActive (false);

			for (int i = 0; i < UIScreens.Length; i++) {
				UIScreens [i].SetActive ((UIScreens [i].name == changeScreen.name) ? true : false);
				if(UIScreens [i].name == changeScreen.name)
					UIScreens[i].GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0, 1, Time.time);
			}
		} else {
			instantiateScreen.SetActive(true);

			for(int i = 0; i < UIScreens.Length; i++)
				UIScreens[i].SetActive(false);
		}
	}
}
