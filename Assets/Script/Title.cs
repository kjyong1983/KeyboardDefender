using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

	string userName;

	void Start()
	{
		
	}

	public void StartGame()
	{
		userName = GameObject.Find("InputField").GetComponent<InputField>().text;
		SetName(userName);
		LoadGame(1);
	}

	void SetName(string str)
	{
		PlayerPrefs.SetString("NAME", str);
	}

	void LoadGame(int sceneNumber)
	{
		SceneManager.LoadScene(sceneNumber);
	}
}
