using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class FightManager : MonoBehaviour
{
    public Tanks.AbstractTank[] tanks;
    // Start is called before the first frame update
    void Start()
    {
        tanks = GameObject.FindObjectsOfType<Tanks.AbstractTank>();
        foreach (Tanks.AbstractTank t in tanks)
        {
            t.SetFightManager(this);
        }
        AudioEngine.PlaySound(Sounds.StartHorn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterDeath(Tanks.AbstractTank tank)
    {
        tank.gameObject.SetActive(false);
        Debug.Log(tank.player + " died!");
        Player winner = GetWinner(tank.player);
        GameManager.Instance.TransitionSong();
        StartCoroutine(EndFight(2f, winner));


    }

    private Player GetWinner(Player loser)
    {
        switch(loser)
        {
            case Player.Player1:
                return Player.Player2;
            case Player.Player2:
                return Player.Player1;
        }
        return Player.Player1;
    }

    private IEnumerator EndFight(float delay, Player winner)
    {
        yield return new WaitForSeconds(delay);
        GameManager.Instance.EndFightPhase(winner);
    }
}
