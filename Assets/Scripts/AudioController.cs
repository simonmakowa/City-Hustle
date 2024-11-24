using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    /*public AudioSource musicSource;
    public AudioClip[] musicTracks;

    void Start()
    {
        // Ensure AudioSource is added to MainCamera
        musicSource = Camera.main.gameObject.AddComponent<AudioSource>();
        PlayMusic(0); // Start with first track
    }

    public void PlayMusic(int trackIndex)
    {
        if (trackIndex < musicTracks.Length)
        {
            musicSource.clip = musicTracks[trackIndex];
            musicSource.Play();
        }
    }

    // Button click method
    public void OnGameStartButtonClick()
    {
        PlayMusic(1); // Play second track when game starts
    }*/
    public static AudioController Instance { get; private set; }

    public AudioSource musicSource;
    public AudioClip[] musicTracks;

    void Awake()
    {
        // Singleton pattern: Ensure only one AudioManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Initialize audio source
            musicSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(int trackIndex)
    {
        if (trackIndex < musicTracks.Length)
        {
            // Only change if it's a different track
            if (musicSource.clip != musicTracks[trackIndex])
            {
                musicSource.clip = musicTracks[trackIndex];
                musicSource.Play();
            }
        }
    }

    // Optional: Fade between tracks
    public IEnumerator FadeTrack(int newTrackIndex, float duration = 1.0f)
    {
        float currentTime = 0;
        float start = musicSource.volume;

        // Fade out
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(start, 0, currentTime / duration);
            yield return null;
        }

        // Change track
        PlayMusic(newTrackIndex);

        // Fade in
        currentTime = 0;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(0, start, currentTime / duration);
            yield return null;
        }
    }

}
