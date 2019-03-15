using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject tree, basket, apple, backgroundImage;
    public Text scoreText, strikeText, infoText;
    public GameObject Apple;
    Transform treeTransform, basketTransform;
    public RectTransform treeRectTransform, basketRectTransform;
    public float canvasWidth, canvasHeight, canvasLeftBound, canvasRightBound;
    public float treeX, basketX, xValue;
    public Vector3 temp, mousePosition;
    public GameObject[] remainingApples;
    public int directionChangeChance, score = 0, numStrikes;
    bool mouseWasClicked = false, moveRight = true, applesAreFalling = false, gameIsOver = false;
    public AudioSource appleCollectSound, appleMissSound;

    // Start is called before the first frame update
    void Start()
    {
        //Getting canvas width and height and setting bounds
        canvasWidth = gameObject.GetComponent<RectTransform>().rect.width;
        canvasHeight = gameObject.GetComponent<RectTransform>().rect.height;
        canvasLeftBound = -canvasWidth / 2;
        canvasRightBound = -canvasLeftBound;

        //Getting the Tree
        tree = GameObject.Find("Tree");
        treeTransform = tree.GetComponent<Transform>();
        treeRectTransform = tree.GetComponent<RectTransform>();

        //Getting the Basket
        basket = GameObject.Find("Basket");
        basketTransform = basket.GetComponent<Transform>();
        basketRectTransform = basket.GetComponent<RectTransform>();

        //Getting the score and strikes
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        scoreText.text = score.ToString();
        strikeText = GameObject.Find("Strikes").GetComponent<Text>();
        strikeText.text = "X X X";
        numStrikes = 3;

        //Setting Info Text
        infoText = GameObject.Find("InfoText").GetComponent<Text>();
        infoText.text = "Left Click to Start";

        //Getting Sound Effects
        appleCollectSound = GameObject.Find("AppleCollect").GetComponent<AudioSource>();
        appleMissSound = GameObject.Find("AppleMiss").GetComponent<AudioSource>();

        //Set background Image to fill screen
        backgroundImage = GameObject.Find("BackgroundImage");
        backgroundImage.GetComponent<RectTransform>().sizeDelta = new Vector2(canvasWidth, canvasHeight);

    }

    // Update is called once per frame
    void Update()
    {
        treeX = treeRectTransform.anchoredPosition.x;
        basketX = basketRectTransform.anchoredPosition.x;

        if (Input.GetMouseButton(0))
        {
            mouseWasClicked = true;
            infoText.text = "";
        }

        if (mouseWasClicked)
        {
            if (gameIsOver)
            {
                gameIsOver = false;
                strikeText.text = "X X X";
            }

            scoreText.text = score.ToString();

            if (!applesAreFalling)
            {
                InvokeRepeating("CreateApple", 0.0f, 0.5f);
                applesAreFalling = true;
            }

            ChangeTreeDirectionOnEdge();
            ChangeTreeDirectionByChance();
            BindBasketToMouse();
            KeepBasketInBounds();
        }

    }

    //Generates an apple at the location of the tree
    void CreateApple()
    {
        Instantiate(Apple, treeTransform.position, Quaternion.identity);
    }

    //changes tree direction when on edges is hit
    void ChangeTreeDirectionOnEdge()
    {
        if (treeX >= canvasRightBound - 50)
        {
            moveRight = false;
        }
        else if (treeX <= canvasLeftBound + 50)
        {
            moveRight = true;
        }

        if (moveRight)
            treeTransform.Translate(Vector3.right * 3f * Time.deltaTime);
        else
            treeTransform.Translate(-Vector3.right * 3f * Time.deltaTime);
    }

    //1 in 35 chance of changing the tree direction
    void ChangeTreeDirectionByChance()
    {
        directionChangeChance = Random.Range(1, 36);
        if (directionChangeChance == 1)
        {
            if (moveRight)
            {
                moveRight = false;
                treeTransform.Translate(-Vector3.right * 3f * Time.deltaTime);
            }
            else
            {
                moveRight = true;
                treeTransform.Translate(Vector3.right * 3f * Time.deltaTime);
            }
        }
    }

    //make the basket follow the mouse
    void BindBasketToMouse()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        basketTransform.position = new Vector3(mousePosition.x, basketTransform.position.y, 0);
    }

    //keeps the basket from leaving the canvas
    void KeepBasketInBounds()
    {
        if (basketX > canvasRightBound || basketX < canvasLeftBound)
        {
            xValue = Mathf.Clamp(transform.position.x, canvasLeftBound, canvasRightBound);
            basketTransform.position = new Vector3(xValue, basketTransform.position.y,
               basketTransform.position.z);
        }
    }

    //stops all objects and ends the game
    public void EndGame()
    {
        mouseWasClicked = false;
        applesAreFalling = false;
        CancelInvoke(); //stops apples from falling
        //remove all remaining apples
        remainingApples = GameObject.FindGameObjectsWithTag("apple");
        foreach(GameObject g in remainingApples)
            Destroy(g);
        //infoText.text = "Left Click to Restart";
        score = 0;
        numStrikes = 3;
        gameIsOver = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
    }


}