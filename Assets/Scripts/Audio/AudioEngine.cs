using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioEngine : MonoBehaviour
{

    FMOD.Studio.EventInstance musicInstance;

    private int transitionValue = 0;

    [FMODUnity.EventRef]
    public string gameSongEventName;

    public void ResetSong()
    {
        transitionValue = 0;
        SetParameter("transition", transitionValue);
        musicInstance.setTimelinePosition(0);
    }

    public void TransitionSong()
    {
        SetParameter("transition", ++transitionValue);
    }

    void FMODERR(FMOD.RESULT result)
    {
        if (result != FMOD.RESULT.OK)
        {
            Debug.Log("We have an error in FMOD. ");
            Debug.Log(result.ToString());
        }
    }

    void FMODERR(FMOD.RESULT result, string message)
    {
        if (result != FMOD.RESULT.OK)
        {
            Debug.Log(message);
        }

        FMODERR(result);
    }

    public void SetParameter(string name, float value)
	{
        FMODERR(musicInstance.setParameterByName(name, value), "setting parameter on music instance");
    }


    // Make Audio engine persist through scenes
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AudioManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);

        musicInstance = FMODUnity.RuntimeManager.CreateInstance(gameSongEventName);

        musicInstance.start();
    }

}