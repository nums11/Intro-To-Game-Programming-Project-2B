using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    Button playBtn, highScoreBtn, quitBtn;
    AudioSource btnSound, backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        playBtn = GameObject.Find("PlayBtn").GetComponent<Button>();
        highScoreBtn = GameObject.Find("HighScoreBtn").GetComponent<Button>();
        quitBtn = GameObject.Find("QuitBtn").GetComponent<Button>();
        btnSound = GameObject.Find("ButtonSound").GetComponent<AudioSource>();
        backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        DontDestroyOnLoad(btnSound);
        DontDestroyOnLoad(backgroundMusic);

        //Play background music if it isn't already playing
        if (!backgroundMusic.isPlaying) backgroundMusic.Play();

        //Load the Game Scene on click
        playBtn.onClick.AddListener(() =>
        {
            btnSound.Play();
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        });

        //Load the High Score Scene on click
        highScoreBtn.onClick.AddListener(() =>
        {
            btnSound.Play();
            UnityEngine.SceneManagement.SceneManager.LoadScene("HighScoreScene");
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
