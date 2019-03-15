using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public Button[] buttons;
    Button playBtn, highScoreBtn, quitBtn;
    // Start is called before the first frame update
    void Start()
    {
        buttons = gameObject.GetComponentsInChildren<Button>();
        playBtn = buttons[0];
        highScoreBtn = buttons[1];
        quitBtn = buttons[2];

        //Load the Game Scene on click
        playBtn.onClick.AddListener(() => {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        });

        //Load the High Score Scene on click
        highScoreBtn.onClick.AddListener(() => {
            UnityEngine.SceneManagement.SceneManager.LoadScene("HighScoreScene");
        });

        //Exit the game on click
        quitBtn.onClick.AddListener(() => {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
