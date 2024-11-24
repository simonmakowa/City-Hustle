using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusicController : MonoBehaviour
{
    [SerializeField] private int sceneTrackIndex;
    void Start()
    {
        // Play the scene's specific track
        AudioController.Instance.PlayMusic(sceneTrackIndex);
    }

    public void OnGameStart()
    {
        // Example of changing music when game starts
        AudioController.Instance.PlayMusic(1);
        // Or with fade:
        // StartCoroutine(AudioManager.Instance.FadeTrack(1));
    }
}
