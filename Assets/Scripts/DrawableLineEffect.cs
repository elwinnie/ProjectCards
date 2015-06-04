using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DrawableLineEffect : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public GameObject effectObj;
	public static GameObject cardBeingDragged;

	private Transform startParent;
	private Vector3 startPosition;
	private Vector3 positionCount;
	private Vector3 vectorRay;
	private Vector3 distance;
	private GameObject[] effectsArray;
	private bool isCreate = false;
	private int count;
	private float scaleCount;
	private int oldCount;

	void Awake() {
		count = 1;
		oldCount = 1;
		effectsArray = new GameObject[50];
		scaleCount = 1.5f;
	}

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		cardBeingDragged = gameObject;
		startPosition = transform.position;
		startParent = transform.parent;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
		this.transform.parent.SetAsLastSibling ();
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{	
		positionCount = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 5));
		distance = positionCount - this.transform.position;
		count = Mathf.RoundToInt (distance.magnitude / 60.0f);


		if (oldCount != count) {
			for(int i = 0; i < effectsArray.Length; i++) {
				Destroy(effectsArray[i]);
			}
			scaleCount = 1.5f;
			isCreate = false;
		}

		float sc = 0.7f / count;
		oldCount = count;
		vectorRay = (positionCount - this.transform.position) / (float)count;

		if (isCreate == false) {
			for (int i = 0; i < count; i++) {
				scaleCount -= sc;
				effectsArray [i] = Instantiate (effectObj, this.transform.position, Quaternion.identity) as GameObject;
				effectsArray [i].transform.localScale = new Vector3 (scaleCount, scaleCount, 0f);
				effectsArray [i].transform.SetParent (this.gameObject.transform);
			}
		}

		if (count != 0) {
			for (int i = 0; i < count; i++) {
				effectsArray [i].transform.localPosition = vectorRay * i;

			}
		} else
			return;

		isCreate = true;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		cardBeingDragged = null;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;

		if(transform.parent == startParent)
			transform.position = startPosition;

		for (int i = 0; i < count; i++) {
			Destroy(effectsArray[i]);
		}
		isCreate = false;
		scaleCount = 1.5f;
	}

	#endregion
}
