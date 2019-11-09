using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlexLoadGameTest : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TransitionSong()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        if (audioManager)
            audioManager.GetComponent<AudioEngine>().TransitionSong();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        { 
            SceneManager.LoadScene("AlexAudioScene");
            TransitionSong();

        }
    }
}
