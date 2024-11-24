using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public AudioController controller;

    public void ButtonStart()
    {
        StartCoroutine(AudioController.Instance.FadeTrack(1));
        SceneManager.LoadScene(1);
    }
    public void ButtonQuit() { 
        Application.Quit();
    }
}
