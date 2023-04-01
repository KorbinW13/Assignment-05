using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WordGenerator : MonoBehaviour {

	private static string[] wordList;
    static WordGenerator()
    {
        string path = "Assets/words.txt"; //path of file
        string content = File.ReadAllText(path); // reads everything in the file
        wordList = content.Split(new[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
        //Splits each word in the text file for the array, in this instance, using spaces.
    }

    public static string GetRandomWord ()
	{
		int randomIndex = Random.Range(0, wordList.Length);
		string randomWord = wordList[randomIndex];

		return randomWord;
	}

}
