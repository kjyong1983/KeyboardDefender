using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions : MonoBehaviour {

	string question = "test";

	public bool IsSame(string str)
	{
		if (str.Equals(question))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
