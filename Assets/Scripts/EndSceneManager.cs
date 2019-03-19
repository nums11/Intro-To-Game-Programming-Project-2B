using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneManager : MonoBehaviour
{
    int highScore;
    string rowText;
    Button mainMenuBtn, playAgainBtn, quitBtn;
    AudioSource btnSound;
    // Start is called before the first frame update
    void Start()
    {
        mainMenuBtn = GameObject.Find("MainMenuBtn").GetComponent<Button>();
        playAgainBtn = GameObject.Find("PlayAgainBtn").GetComponent<Button>();
        quitBtn = GameObject.Find("QuitBtn").GetComponent<Button>();
        btnSound = GameObject.Find("ButtonSound").GetComponent<AudioSource>();
        btnSound.volume = PlayerPrefs.GetFloat("volume");
        DontDestroyOnLoad(btnSound);

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

        //Load the Game Scene on click
        mainMenuBtn.onClick.AddListener(() =>
        {
            btnSound.Play();
            UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
        });

        //Load the High Score Scene on click
        playAgainBtn.onClick.AddListener(() =>
        {
            btnSound.Play();
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        });

        //Exit the game on click
        quitBtn.onClick.AddListener(() =>
        {
            btnSound.Play();
            Application.Quit();
        });
    }
    // Update is called once per frame
    void Update()
    {

    }
}
