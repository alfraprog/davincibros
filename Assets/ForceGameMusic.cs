using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceGameMusic : MonoBehaviour
{

    private void Start()
    {
        ForceGameMusicAtStart();
    }

    void ForceGameMusicAtStart()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        if (audioManager)
        {
            audioManager.GetComponent<AudioEngine>().ForceGameSong();
        }
    }
}
