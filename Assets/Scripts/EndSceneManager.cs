using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneManager : MonoBehaviour
{
    Button mainMenuBtn, playAgainBtn, quitBtn;
    // Start is called before the first frame update
    void Start()
    {
        mainMenuBtn = GameObject.Find("MainMenuBtn").GetComponent<Button>();
        playAgainBtn = GameObject.Find("PlayAgainBtn").GetComponent<Button>();
        quitBtn = GameObject.Find("QuitBtn").GetComponent<Button>();

        //Load the Game Scene on click
        mainMenuBtn.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
        });

        //Load the High Score Scene on click
        playAgainBtn.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        });

        //Exit the game on click
        quitBtn.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
    // Update is called once per frame
    void Update()
    {

    }
}
