using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;

public class CardProperties : MonoBehaviour {

	//Свойства карты. Название, урон, цена и т.д.
	private string name;
	private string ability;
	private string spell;
	private string cast;
	private string spellName;
	private string spellTarget;
	private string element;

	[HideInInspector]
	public int level, health, attack, castCost;

	private string caster;
	private string type;

	//Отображение текста на карте. Элементы UI...
	public Text textName;
	public Text healthCount;
	public Text damageCount;
	public Text levelCount;

	//Состояния карты
	private bool cardOnCanvas = false;
	private bool castUsed = false;
	private LoadCardProperties lcp;

	void Awake() {
		lcp = GetComponent<LoadCardProperties> ();
	}

	void Start() {
		name = lcp.properties [0].TrimStart();
		ability = lcp.properties [1].TrimStart();
		spell = lcp.properties [2].TrimStart();
		cast = lcp.properties [3].TrimStart();
		spellName = lcp.properties [4].TrimStart();
		spellTarget = lcp.properties [5].TrimStart();
		element = lcp.properties [6].TrimStart();
		level = Convert.ToInt32 (lcp.properties [7].TrimStart());
		health = Convert.ToInt32 (lcp.properties [8].TrimStart());
		attack = Convert.ToInt32 (lcp.properties [9].TrimStart());
		caster = lcp.properties [10].TrimStart();
		castCost = Convert.ToInt32 (lcp.properties [11].TrimStart ());
		type = lcp.properties [12].TrimStart();

		//Цепляем элементы UI к свойствам карты.
		textName.text = name.ToString ();
		healthCount.text = health.ToString ();
		damageCount.text = attack.ToString ();
		levelCount.text = level.ToString ();
	}
}