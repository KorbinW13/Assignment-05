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
        {
            Word word = wordManager.words[i]; 
            RectTransform rectTransform = word.display.text.GetComponent<RectTransform>(); 
            if (rectTransform.anchoredPosition.y < minYPosition)
            {
                wordManager.RemoveWord(word);
                Destroy(word.display.gameObject);
                i--;
                WordManager.Lives--;
            }
        }
    }
}