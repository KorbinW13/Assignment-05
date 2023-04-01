using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WordManager : MonoBehaviour {

	public List<Word> words;
    public static AudioSource Key;

    public Text LivesText;
	public static int Lives;
    public static bool gameIsPaused = false;
    public GameObject pauseTextObject;

    public WordSpawner wordSpawner;

	private bool hasActiveWord;
	private Word activeWord;

	void Start () 
	{
        gameIsPaused = false;
		Lives = 3;
        Time.timeScale = 1;
        Key = GetComponent<AudioSource>();
    }

    private void Update()
    {
        LivesText.text = "Lives: " + Lives;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (Lives < 0)
		{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void AddWord ()
	{
		Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
		Debug.Log(word.word);

		words.Add(word);
        Score.TotalWords++;
    }

	public void TypeLetter (char letter)
	{
		if (hasActiveWord)
		{
			if (activeWord.GetNextLetter() == letter)
			{
                activeWord.TypeLetter();
			}
		} else
		{
			foreach(Word word in words)
			{
				if (word.GetNextLetter() == letter)
				{
					activeWord = word;
					hasActiveWord = true;
					word.TypeLetter();
					break;
				}
			}
		}

		if (hasActiveWord && activeWord.WordTyped())
		{
			hasActiveWord = false;
			words.Remove(activeWord);
		}
	}

    public void RemoveWord(Word wordToRemove)
    {
        if (hasActiveWord && activeWord == wordToRemove)
        {
            hasActiveWord = false;
        }
        words.Remove(wordToRemove);
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        pauseTextObject.SetActive(true);
        gameIsPaused = true;
        GetComponent<WordInput>().enabled = false; 
    }
    void ResumeGame()
    {
        pauseTextObject.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        GetComponent<WordInput>().enabled = true;
    }
}
