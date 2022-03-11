using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextFlash : MonoBehaviour
{

    public TMP_Text textToFlash;  //Add reference to UI Text here via the inspector
    private float timeToAppear = .5f;
    private float timeWhenDisappear;

    //Call to enable the text, which also sets the timer
    public void EnableText()
    {
        textToFlash.enabled = true;
        timeWhenDisappear = Time.time + timeToAppear;
    }

    //We check every frame if the timer has expired and the text should disappear
    void Update()
    {
        if (textToFlash.enabled && (Time.time >= timeWhenDisappear))
        {
            textToFlash.enabled = false;
        }
    }
}
