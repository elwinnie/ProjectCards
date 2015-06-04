using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class AnimManager : MonoBehaviour {
	public Animator initiallyOpen;
	private Animator m_Open;
	private int m_OpenParameterId;

	const string k_OpenTransitionName = "IsOpen";
	const string k_ClosedStateName = "FadeOut";
	
	public void OnEnable()
	{
		m_OpenParameterId = Animator.StringToHash (k_OpenTransitionName);

		if (initiallyOpen == null)
			return;
		OpenPanel(initiallyOpen);
	}

	public void OpenPanel (Animator anim)
	{
		if (m_Open == anim)
			return;
		anim.gameObject.SetActive(true);
		anim.transform.SetAsLastSibling();

		StartCoroutine (AnimOpened (anim));
		
		CloseCurrent();

		m_Open = anim;
		m_Open.SetBool(m_OpenParameterId, true);
	}

	public void CloseCurrent()
	{
		if (m_Open == null)
			return;
	
		m_Open.SetBool(m_OpenParameterId, false);
		StartCoroutine (AnimClosed(m_Open));
		m_Open = null;
	}

	IEnumerator AnimClosed(Animator anim) {
		bool animControll = false, waitToClose = true;

		while (!animControll) {
			animControll = anim.GetCurrentAnimatorStateInfo(0).IsName("FadeOut");
			//anim.GetComponent<CanvasGroup> ().blocksRaycasts = anim.GetComponent<CanvasGroup> ().interactable = false;

			waitToClose = !anim.GetBool("IsOpen");

			yield return new WaitForEndOfFrame();
		}
		//anim.GetComponent<CanvasGroup> ().blocksRaycasts = anim.GetComponent<CanvasGroup> ().interactable = true;
		if(waitToClose)
			anim.gameObject.SetActive (false);
	}

	IEnumerator AnimOpened(Animator anim) {
		bool animControll = false;
		
		while (!animControll) {
			animControll = anim.GetCurrentAnimatorStateInfo(0).IsName("FadeIn");
			//anim.GetComponent<CanvasGroup> ().blocksRaycasts = anim.GetComponent<CanvasGroup> ().interactable = false;
			
			yield return new WaitForEndOfFrame();
		}
		//anim.GetComponent<CanvasGroup> ().blocksRaycasts = anim.GetComponent<CanvasGroup> ().interactable = true;
	}
}