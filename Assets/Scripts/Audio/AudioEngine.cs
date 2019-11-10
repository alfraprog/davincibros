using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioEngine : MonoBehaviour
{
    static Dictionary<string, FMOD.Studio.EventInstance> events = new Dictionary<string, FMOD.Studio.EventInstance>();


    public static void PlaySound(string name)
    {
        //FMODUnity.RuntimeManager.LoadBank("SoundEffects", true);
        

        Debug.Log("This happened?? play sound");

        if (!events.ContainsKey(name))
        {

                try
                {
                    FMOD.Studio.EventInstance instance = FMODUnity.RuntimeManager.CreateInstance(name);

                    events.Add(name, instance);

                }
                catch (FMODUnity.EventNotFoundException e)
                {
                    Debug.LogWarning("Can't find FMOD event name " + name);
                }
        }

        if (events.ContainsKey(name))
            events[name].start();
    }

    FMOD.Studio.EventInstance musicInstance;

    private int transitionValue = 0;

    [FMODUnity.EventRef]
    private string gameSongEventName = "event:/Gamemusic";

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