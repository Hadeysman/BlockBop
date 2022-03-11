using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void PlayGame()
    {
        print("Button is being pressed");
        SceneManager.LoadScene("GameStart", LoadSceneMode.Single);
    }
}
