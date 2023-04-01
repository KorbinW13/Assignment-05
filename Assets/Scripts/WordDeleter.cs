using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDeleter : MonoBehaviour
{
    public Canvas canvas;
    public WordManager wordManager;
    private float minYPosition = -325f;

    void Update()
    {
        for (int i = 0; i < wordManager.words.Count; i++)
        { // goes through each word and finds the one first needing to be deleted
          // to be deleted
            Word word = wordManager.words[i]; //grabs Words from Word.cs and wordManager words.
            RectTransform rectTransform = word.display.text.GetComponent<RectTransform>(); // checks the RectTransform, and follows the text on the Y position.
            if (rectTransform.anchoredPosition.y < minYPosition)
            {  //"minYPosition" will be the "trigger" for deleting it once at a specific Y position.
                wordManager.RemoveWord(word); // deletes the word from a new specific method in Word.cs
                Destroy(word.display.gameObject); // destroys
                i--;
                WordManager.Lives--;
            }
        }
    }
}