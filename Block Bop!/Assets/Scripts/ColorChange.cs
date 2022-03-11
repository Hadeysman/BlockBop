using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorChange : MonoBehaviour
{
    Dictionary<string, Color32> colorDict = new Dictionary<string, Color32>();

    
    public TMP_Text text;
    public TMP_Text nextText;
    private Queue<KeyValuePair<string, Color32>> textQueue = new Queue<KeyValuePair<string, Color32>>();
    public Image timerBar;

    public float barMaxTime = 5f;
    float barTimeLeft;

    void Start()
    {
        colorDict.Add("Red", new Color32(255, 0, 0, 255));
        colorDict.Add("Blue", new Color32(0, 0, 255, 255));
        colorDict.Add("Green", new Color32(0, 255, 0, 255));
        fillQueue();
        fillQueue();
        changeColor();
        barTimeLeft = barMaxTime;
    }

    void Update()
    {
        if (barTimeLeft > 0)
        {
            barTimeLeft -= Time.deltaTime;
            timerBar.fillAmount = barTimeLeft / barMaxTime;
        }
        else
        {
            barTimeLeft = barMaxTime;
            timerBar.fillAmount = barTimeLeft / barMaxTime;
            changeColor();

        }
    }

    void fillQueue()
    {
        KeyValuePair<string, Color32> randomColor = colorDict.ElementAt(Random.Range(0, colorDict.Count));
        textQueue.Enqueue(randomColor);
    }


    void changeColor()
    {

        //We want to change the color of the text at the top of the screen on a regular interval.
        print("**Calling Change Color**");

        KeyValuePair<string, Color32> currentColor = textQueue.Dequeue();
        
        text.color = currentColor.Value;
        text.text = currentColor.Key;

        KeyValuePair<string, Color32> nextColor = textQueue.Peek();

        //This next line is to take the color and reduce the alpha of the color to reduce visibility
        Color32 colorFix = nextColor.Value;
        colorFix.a = 100;

        nextText.color = colorFix;
        nextText.text = nextColor.Key;
        fillQueue();

     
        

    }
}
