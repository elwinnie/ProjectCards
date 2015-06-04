using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {
	public GameObject card {
		get {
			if(transform.childCount > 0)
				return transform.GetChild(0).gameObject;
			return null;
		}
	}

	#region IDropHandler implementation

	public void OnDrop (PointerEventData eventData)
	{
		if (!card) {
			DrawableLineEffect.cardBeingDragged.transform.SetParent(transform);
		}
	}

	#endregion
}
