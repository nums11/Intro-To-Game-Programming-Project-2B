using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    Button playBtn, highScoreBtn, quitBtn;
    AudioSource btnSound, backgroundMusic;
    Slider volumeSlider;
    float audioValue;
    // Start is called before the first frame update
    void Start()
    {
        playBtn = GameObject.Find("PlayBtn").GetComponent<Button>();
        highScoreBtn = GameObject.Find("HighScoreBtn").GetComponent<Button>();
        quitBtn = GameObject.Find("QuitBtn").GetComponent<Button>();
        btnSound = GameObject.Find("ButtonSound").GetComponent<AudioSource>();
        backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        volumeSlider = GameObject.Find("VolumeController").GetComponent<Slider>();
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

        createLeaderBoard();
        setVolumeControl();
        volumeSlider.onValueChanged.AddListener(delegate { updateVolume(); });
    }

    //creates the leaderboard if it doesn't already exist
    void createLeaderBoard()
    {
        if (!PlayerPrefs.HasKey("Leaderboard"))
        {
            print("Leader board did not exist");
            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                    PlayerPrefs.SetInt("Leaderboard", 0);
                else
                    PlayerPrefs.SetInt("Leaderboard" + i, 0);
            }
        } else
        {
            print("Leaderboard already existed");
        }
    }

    //set the volume
    void setVolumeControl()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
            volumeSlider.value = PlayerPrefs.GetFloat("volume");
        } else
        {
            volumeSlider.value = PlayerPrefs.GetFloat("volume");
            updateVolume();
        }
    }

    //update the volume when it is changed
    void updateVolume()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        backgroundMusic.volume = PlayerPrefs.GetFloat("volume");
        btnSound.volume = PlayerPrefs.GetFloat("volume");
    }

}
