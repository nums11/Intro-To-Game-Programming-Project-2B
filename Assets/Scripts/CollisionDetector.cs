using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    GameManager gameManager;
    GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        gameManager = canvas.GetComponent<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Basket")
        {
            IncrementScore();
            Destroy(gameObject);
            gameManager.appleCollectSound.Play();
        } else if(col.gameObject.name == "Canvas")
        {
            Destroy(gameObject);
            DecrementStrikes();
            gameManager.appleMissSound.Play();
        }
    }

    //increments the player score
    void IncrementScore()
    {
        gameManager.score++;
    }

    //decreases the number of remaining strikes
    void DecrementStrikes()
    {
        if(gameManager.numStrikes == 3)
        {
            gameManager.numStrikes--;
            gameManager.strikeText.text = "  X X";
        }
        else if (gameManager.numStrikes == 2)
        {
            gameManager.numStrikes--;
            gameManager.strikeText.text = "    X";
        }
        else if (gameManager.numStrikes == 1)
        {
            gameManager.numStrikes--;
            gameManager.strikeText.text = "";
            gameManager.EndGame();
        }
    }

}
