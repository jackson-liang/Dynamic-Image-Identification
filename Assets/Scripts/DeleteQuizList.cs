﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Xml;
using System.IO;

public class DeleteQuizList : MonoBehaviour {

	string defaultPath ;
	ManageXML mgXml;
	Button obj;
	public Button buttonprefab;
	void Start () {

		mgXml = new ManageXML ();

		defaultPath = mgXml.Settings();
		if (!Directory.Exists (defaultPath)) {
			Application.LoadLevel ("SettingsScene");
		} else {
			DirectoryInfo info = new DirectoryInfo (defaultPath);
			FileInfo[] fileInfo = info.GetFiles ("*.qz");
			foreach (FileInfo files in fileInfo) {
				//for(int i=0;i<5;i++){

				obj = Instantiate (buttonprefab) as Button;
				obj.name = files.Name;
				obj.GetComponentInChildren <Text> ().text = files.Name;
				string name = obj.name;
				obj.onClick.AddListener (() => OnClicked (name));
				obj.transform.SetParent (GameObject.FindGameObjectWithTag ("quizpanel").transform, false);
			}
		}

	}

	string path;

	public void OnClicked(string name)
	{
		path = defaultPath + "/" + name;
		bt_name = name;

		popup.SetActive (true);

		//GameObject obj = GameObject.Find (name);

		//Debug.Log (PlayGameScript.quizname);
		//SceneManager.LoadScene("startQuiz");
	}
	string bt_name;
	public GameObject popup;
	public void yes()
	{
		
		if(System.IO.File.Exists(path) == true)
		{
			System.IO.File.Delete (path);
		} //PlayGameScript.quizname = name;
		Destroy(GameObject.Find(bt_name));
		popup.SetActive (false);
	}

	public void no()
	{
		popup.SetActive (false);	
	}

	public void Back()
	{
		SceneManager.LoadScene ("StartScene");
	}
}
