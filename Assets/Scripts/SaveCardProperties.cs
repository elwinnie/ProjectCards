using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System;

public class SaveCardProperties : MonoBehaviour {
	CardProperties cardObject;
	string words = "SPELL\t $Dark Summon ^summons a $Ghost ^into free slot. Can only cast if creature died in the presence of Necromancer.";
	List<string> split;

	private string fileName = "Assets/Config/";
	void Start () {
		split = new List<string> ();
		split.AddRange(words.Split(new char[] {' ', '\t'}));

		foreach (string s in split) {
			if(s != "SPELL" && s != "")
				Debug.Log(s.TrimStart());
		}

		cardObject = GetComponent<CardProperties> ();

		if(!File.Exists(fileName + this.gameObject.name + ".inf")) {
			fileName = fileName + this.gameObject.name + ".inf";

			StreamWriter sw = new StreamWriter(fileName);

			sw.WriteLine("NAME\t" + cardObject.name.ToUpper());
			sw.WriteLine();
			//sw.WriteLine("ABILITY\t" + cardObject.ability);

			sw.Close();
		}
		else {
		}
	}
}
