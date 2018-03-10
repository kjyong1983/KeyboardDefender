using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionParser : MonoBehaviour {

    public TextAsset data;
    public SortedDictionary<string, List<string>> voca;

	void Awake () 
	{
        voca = new SortedDictionary<string, List<string>>();
        CsvToDictionary(data.text);
        // Test();    
    }
	
    public void CsvToDictionary(string data)
    {
        fgCSVReader.LoadFromString(data, DictionaryDelegate);
    }

//Debug Section
#region
    void Test()
    {
        for (int i = 1; i < voca.Count; i++)
        {
            Debug.Log(i.ToString() + ": ");
            ShowContent(voca[i.ToString()]);
        }
    }

    void ShowContent(List<string> list)
    {
        for (int j = 0; j < list.Count; j++)
        {
            Debug.Log(list[j]);
        }
    }
#endregion

    void DictionaryDelegate(int index, List<string> line)
    {
        if (index == 0)
        {
            return;
        }
        for (int i = 0; i < line.Count; i++)
        {

            if (i == 0)
            {
                List<string> lines = new List<string>();
                voca.Add(index.ToString(), lines);
            }
            voca[index.ToString()].Add(line[i]);

        }
    }

}