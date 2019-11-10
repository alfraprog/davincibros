using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public class TankConfig
    {
        public AbstractManuscript wheel_left;
        public AbstractManuscript wheel_right;

        public AbstractManuscript weapon_L0_left;
        public AbstractManuscript weapon_L0_right;
        public AbstractManuscript weapon_L1_left;
        public AbstractManuscript weapon_L1_right;
        public AbstractManuscript weapon_L2_left;
        public AbstractManuscript weapon_L2_right;

        public AbstractManuscript armor_L0;
        public AbstractManuscript armor_L1;
        public AbstractManuscript armor_L2;

        public AbstractManuscript flight;
    }

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

    public List<Book> selectedManuscripts = new List<Book>();

    public string manuscriptSelectionScene;
    public string buildingScene;
    public string[] fightScenes;
    public string gameOverScene;

    public GamePhase gamePhase = GamePhase.ManuscriptSelect;
    public int fightStage = 0;

    public List<Player> fightWinners = new List<Player>();

    public TankConfig tankConfigP1 = new TankConfig();
    public TankConfig tankConfigP2 = new TankConfig();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame() {
        gamePhase = GamePhase.ManuscriptSelect;
        TransitionSong();
        LoadSceneForGamePhase();
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

    public void EndManuscriptSelectPhase(Book p1Book, Book p2Book)
    {
        selectedManuscripts = new List<Book>();
        selectedManuscripts.Add(p1Book);
        selectedManuscripts.Add(p2Book);
        
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
