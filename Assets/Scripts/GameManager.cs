using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
//using Palmmedia.ReportGenerator.Core.Common;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    PlayerController playerController;

    public TMP_Text HScoreText;
    public TMP_Text ScoreText;

    private int Score;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
       
        HScoreText.text = $" HSCORE: {PlayerPrefs.GetInt("HIGHSCORE")}";

    }

    // Update is called once per frame
    void Update()
    {

        Score = (int)Time.timeSinceLevelLoad;
        ScoreText.text = $" SCORE: {Score.ToString("0")}";
        
        if (Input.anyKey && Time.timeScale == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;

        }
        
        // Setting High Score
        if (playerController.isgameOver)
        {
            if(Score > PlayerPrefs.GetInt("HIGHSCORE"))
            {
                PlayerPrefs.SetInt("HIGHSCORE", Score);

            }
        }
    }
    
    
}
