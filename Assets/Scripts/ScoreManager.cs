using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{


    public static int score = 0;
    public static int highScore = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    
    private string highScoreKey = "HighScore";
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
        
        //Reset high score
        // Reset();
    }

    // Update is called once per frame
    void Update()
    {

        //Save highscore
        if (score > highScore)
        {
            PlayerPrefs.SetInt(highScoreKey, score);
            PlayerPrefs.Save();
        }
        
        //leading 0s
        scoreText.text = score.ToString("0000");
        highScoreText.text = highScore.ToString("0000");
    }


    private void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
    
}
