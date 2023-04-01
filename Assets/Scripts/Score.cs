using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static float TotalWords;
    public static float TotalCharTyped;
    public static float TotalCharCorrect;
    private float percCorrect = (TotalCharCorrect / TotalCharTyped) * 100;
    
    public Text TotalWordText;
    public Text CharacterText;
    public Text CorrectCharText;
    public Text PercentCorrectText;
    public Text PlayerText;



    // Start is called before the first frame update
    void Start()
    {
        TotalWordText.text = "Number of Total Words spawned: " + TotalWords;
        CharacterText.text = "Number of Characters typed: " + TotalCharTyped;
        CorrectCharText.text = "Number of Characters typed correct: " + TotalCharCorrect;
        PercentCorrectText.text = "Percent correct: " + percCorrect.ToString("F2") + "%";
        PlayerText.text = InputName.PlayerName;
    }
}
