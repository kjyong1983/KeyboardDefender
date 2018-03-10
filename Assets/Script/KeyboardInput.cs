using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using DG.Tweening;
public class KeyboardInput : MonoBehaviour {

	StringBuilder stringBuilder;
	[HideInInspector]public string answer;
	bool getInputState = true;
	Button button;
	Sequence sequence;

	// Use this for initialization
	void Start () {
		sequence = DOTween.Sequence();
		stringBuilder = new StringBuilder();
		button = GameObject.Find("a").GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (getInputState)
		{
			if (Input.anyKeyDown)
			{
				Debug.Log("input: " + Input.inputString);
				
				if (!Input.inputString.Equals(""))
				{
					var input = Input.inputString.ToLower();
					if (Input.inputString.Length > 1)
					{
						input = input.Substring(Input.inputString.Length-1, 1);
					}
					var button = GameObject.Find(input).GetComponentInChildren<BoxCollider>().gameObject;					
					//scale won't return to its original value!
					// sequence.Append(
						button.transform.DOPunchScale(Vector3.forward * 20, 1f, 15, 1).SetEase(Ease.OutQuint);
						// button.transform.DOShakeScale(1).SetEase(Ease.OutQuint)
					// 	);
					// sequence.Append(
					// 	button.transform.DOScaleZ(20,0.1f).SetEase(Ease.InExpo)
					// 	);
					// button.transform.DOScaleZ(20, .1f);
				}

				if (Input.GetKeyDown(KeyCode.Return))
				{
					answer = stringBuilder.ToString();
					Debug.Log("answer: " + answer);
					stringBuilder.Remove(0, stringBuilder.Length);

					var gameManager = FindObjectOfType<GameManager>();
					gameManager.CompareAnswer(answer);

					answer = "";
				}
				else
				{
					Debug.Log(Input.inputString);
					stringBuilder.Append(Input.inputString);		
				}
			}
		}

	}
}
