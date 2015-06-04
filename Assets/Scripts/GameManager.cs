using UnityEngine;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour {
	public List<GameObject> backgrounds = new List<GameObject>();
	public List<GameObject> airCards = new List<GameObject>();
	public List<GameObject> fireCards = new List<GameObject>();
	public List<GameObject> deathCards = new List<GameObject>();
	public List<GameObject> earthCards = new List<GameObject>();
	public List<GameObject> lifeCards = new List<GameObject>();
	public List<GameObject> waterCards = new List<GameObject>();

	public string[] playersName;

	private Transform playerHolder;
	private Transform elementHolder;
	//private List<Vector3> gridPosition = new List<Vector3>;

	void PlayerManager (string name) {
		playerHolder = new GameObject (name).transform;
	}

	void RandomObjects(List<GameObject> arrayObjects, int minimum, int maximum, string element) {

		elementHolder = new GameObject (element).transform;
		elementHolder.transform.SetParent (playerHolder);

		int objectCount = Random.Range (minimum, maximum);

		for (int i = 0; i < objectCount; i++) {
			int count = Random.Range (0, arrayObjects.Count);
			GameObject objectChoice = arrayObjects [count];
			arrayObjects.RemoveAt(count);
			GameObject instance = Instantiate(objectChoice, new Vector3(0, 0, 0f), Quaternion.identity) as GameObject;
			instance.transform.SetParent(elementHolder);
		}
	}

	void Awake() {
		GameObject instance = Instantiate(backgrounds[0], new Vector3(0, 0, 0f), Quaternion.identity) as GameObject;

		for (int i = 0; i < 2; i++) {
			PlayerManager (playersName [i]);
			RandomObjects (airCards, 4, 7, "Air");
		}
	}
}
