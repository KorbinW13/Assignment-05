using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseTextObject;
    public GameObject WordMangerObj;

    public void Resume()
    {
        pauseTextObject.SetActive(false);
        Time.timeScale = 1f;
        WordManager.gameIsPaused = false;
        GameObject.Find("WordManager").GetComponent<WordInput>().enabled = true;
    }
}
