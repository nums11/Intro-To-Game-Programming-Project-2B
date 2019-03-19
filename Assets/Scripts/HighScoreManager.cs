using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    int highScore;
    string rowText;
    Button mainMenuBtn;
    AudioSource btnSound;
    // Start is called before the first frame update
    void Start()
    {
        //Display all the high scores
        for (int i = 0; i < 10; i++)
        {
            //Get the score
            if(i == 0)
                highScore = PlayerPrefs.GetInt("Leaderboard");
            else
                highScore = PlayerPrefs.GetInt("Leaderboard" + i);
            //make the text for this row in the leaderboard
            rowText = (i + 1).ToString() + ". " + highScore.ToString();
            //Find the associeated Text field and set it's value
            GameObject.Find(i.ToString()).GetComponent<Text>().text = rowText;
        }

        //Load Title Scene and play button sound on click
        btnSound = GameObject.Find("ButtonSound").GetComponent<AudioSource>();
        btnSound.volume = PlayerPrefs.GetFloat("volume");
        DontDestroyOnLoad(btnSound);
        mainMenuBtn = GameObject.Find("MainMenuBtn").GetComponent<Button>();
        mainMenuBtn.onClick.AddListener(() =>
        {
            btnSound.Play();
            UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
