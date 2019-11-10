using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public enum Player
    {
        Player1,
        Player2
    }

    public enum GamePhase
    {
        ManuscriptSelect,
        Build,
        Fight,
        GameOver
    }

    public string manuscriptSelectionScene;
    public string buildingScene;
    public string[] fightScenes;
    public string gameOverScene;

    public GamePhase gamePhase = GamePhase.ManuscriptSelect;
    public int fightStage = 0;

    public List<Player> fightWinners = new List<Player>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadSceneForGamePhase()
    {
        switch(gamePhase)
        {
            case GamePhase.ManuscriptSelect:
                SceneManager.LoadScene(manuscriptSelectionScene);
                break;
            case GamePhase.Build:
                SceneManager.LoadScene(buildingScene);
                break;
            case GamePhase.Fight:
                SceneManager.LoadScene(fightScenes[fightStage]);
                break;
            case GamePhase.GameOver:
                SceneManager.LoadScene(gameOverScene);
                break;
        }
    }

    public void TransitionSong()
    {
        GameObject audioManger = GameObject.FindGameObjectWithTag("AudioManager");
        if (audioManger != null)
        {
            audioManger.GetComponent<AudioEngine>().TransitionSong();
        }
    }

    public void ResetSong()
    {
        GameObject audioManger = GameObject.FindGameObjectWithTag("AudioManager");
        if (audioManger != null)
        {
            audioManger.GetComponent<AudioEngine>().ResetSong();
        }
    }

    public void EndManuscriptSelectPhase()
    {
        //Todo persist any data in the GameManager
        gamePhase = GamePhase.Build;
        TransitionSong();
        LoadSceneForGamePhase();
    }

    public void EndBuildPhase()
    {
        //Todo persist any data in the GameManager
        gamePhase = GamePhase.Fight;
        TransitionSong();
        LoadSceneForGamePhase();
    }

    public void EndFightPhase(Player winner)
    {
        fightWinners.Add(winner);
        //Todo persist any data in the GameManager
        fightStage++;
        if (fightStage >= fightScenes.Length)
        {
            gamePhase = GamePhase.GameOver;

        } else
        {
            gamePhase = GamePhase.ManuscriptSelect;
        }
        ResetSong();
        LoadSceneForGamePhase();
    }

}
