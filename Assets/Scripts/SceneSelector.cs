using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public void StartGame()
    {
        Score.TotalWords = 0;
        Score.TotalCharTyped = 0;
        Score.TotalCharCorrect = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Title");
    }
}
