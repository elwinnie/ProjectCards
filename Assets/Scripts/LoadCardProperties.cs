using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System;

public class LoadCardProperties : MonoBehaviour {
	private string fileName = "Assets/Config/";
	private List<string> stringArray;

	[HideInInspector]
	public List<string> properties;

	void Awake() {
		stringArray = new List<string>();
		properties = new List<string>();

		StreamReader streamReader = new StreamReader (fileName + this.gameObject.name + ".inf");

		if (streamReader != null) {
			string tempLoad;
			while(!streamReader.EndOfStream) {
				string readLine = streamReader.ReadLine();
				stringArray.AddRange(readLine.Split(new char[] {' ', '\t'}));

				if(stringArray[0] != "") {
					stringArray.RemoveAt(0);
					tempLoad = string.Join(" ", stringArray.ToArray());
					properties.Add(tempLoad);
				}
				stringArray.Clear();
			}
		}
	}
}
