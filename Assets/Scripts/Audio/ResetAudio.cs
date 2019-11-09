using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAudio : MonoBehaviour
{
    public void ResetMusic()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        if (audioManager)
            audioManager.GetComponent<AudioEngine>().ResetSong();
    }
}
