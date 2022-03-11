using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BopBlock : MonoBehaviour
{
    public TMP_Text colorToHit;
    public TMP_Text scoreText;
    public TMP_Text countdownText;
    public TMP_Text addTime;
    public TMP_Text subTime;
    public TMP_Text addScore;
    public TMP_Text levelText;
    


    private int score;
    private int level = 1;
    private float countdown = 60f;
    [SerializeField]
    private AudioSource soundOnHit;
    [SerializeField]
    private AudioSource soundOnMiss;
    [SerializeField]
    private GameObject gameOver;

    private int blockLayerOrder = 0;

    void Start()
    {
        level = 1;
    }


    void Update()
    {
        
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (IsTouchOverThisObject(touch))
                {
                    Destroy(gameObject, 0);
                }
            }
            else if (Input.GetMouseButtonDown(0))
            {
                
                RaycastHit2D hit = captureClick();
                bool getPoint = false;
                if (hit.collider != null)
                {
                    GameObject hitObject = hit.collider.gameObject;
                    if (hitObject.tag.Equals("BlockToBop") && hitObject.GetComponent<SpriteRenderer>().color == colorToHit.color)
                    {
                        getPoint = true;
                        Destroy(hitObject, 0);
                        
                    }
                }
                if(getPoint == true)
                {
                    score += level;
                    addScore.GetComponent<TextFlash>().EnableText();
                    countdown += level;
                    addTime.GetComponent<TextFlash>().EnableText();
                    scoreText.text = score.ToString();
                    soundOnHit.Play();
                    level = score / 10;
                    
                }
                else
                {
                    countdown -= level;
                    subTime.GetComponent<TextFlash>().EnableText();
                    soundOnMiss.Play();
                }
                levelText.text = level.ToString();
                getPoint = false;

            }
        }
        else
        {
            //Turn on game over Canvas
            gameOver.SetActive(true);
        }
        DisplayTime(countdown);

    }

    bool IsTouchOverThisObject(Touch touch)
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(touch.position.x, touch.position.y, 0));
        RaycastHit hit;
        return false; 
    }

    RaycastHit2D captureClick()
    {
        Vector2 mousePos2D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        return hit; 
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
