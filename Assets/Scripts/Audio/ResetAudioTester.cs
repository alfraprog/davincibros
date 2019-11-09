using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetAudioTester : MonoBehaviour
{

    public ResetAudio resetAudio;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        { 
            if (resetAudio)
            {
                SceneManager.LoadScene("AlexCardSelection");
                resetAudio.ResetMusic();
            }
        }
    }
}
