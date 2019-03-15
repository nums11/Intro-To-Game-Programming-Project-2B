using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneManager : MonoBehaviour
{
    Button mainMenuBtn, playAgainBtn, quitBtn;
    AudioSource btnSound;
    // Start is called before the first frame update
    void Start()
    {
        mainMenuBtn = GameObject.Find("MainMenuBtn").GetComponent<Button>();
        playAgainBtn = GameObject.Find("PlayAgainBtn").GetComponent<Button>();
        quitBtn = GameObject.Find("QuitBtn").GetComponent<Button>();
        btnSound = GameObject.Find("ButtonSound").GetComponent<AudioSource>();
        DontDestroyOnLoad(btnSound);

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
