using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class RandomFightManager : FightManager
{

    // Start is called before the first frame update
    void Start()
    {
        Library library = GameObject.FindObjectOfType<Library>();
        library.LoadLibrary();
        tanks = GameObject.FindObjectsOfType<Tanks.TankController>();
        foreach (Tanks.TankController t in tanks)
        {
            SetupTank(t, library);
            t.SetFightManager(this);
            t.InitComponents();
        }
        AudioEngine.PlaySound(Sounds.StartHorn);
    }

    private void SetupTank(Tanks.TankController tank, Library library)
    {
        if (library.armorManuscripts.Length > 0)
        {
            tank.armorManuscript = library.armorManuscripts[Random.Range(0, library.armorManuscripts.Length)];
        }

        tank.leftWeaponManuscripts = new WeaponManuscript[tank.leftWeapons.Length];
        for (int i = 0; i < tank.leftWeapons.Length; i++)
        {
            tank.leftWeaponManuscripts[i] = library.weaponManuscripts[Random.Range(0, library.weaponManuscripts.Length)];
        }

        tank.rightWeaponManuscripts = new WeaponManuscript[tank.rightWeapons.Length];
        for (int i = 0; i < tank.leftWeapons.Length; i++)
        {
            tank.rightWeaponManuscripts[i] = library.weaponManuscripts[Random.Range(0, library.weaponManuscripts.Length)];
        }

        tank.flyingManuscript = library.flyingManuscripts[Random.Range(0, library.flyingManuscripts.Length)];
        tank.propulsionManuscript = library.propulsionManuscripts[Random.Range(0, library.propulsionManuscripts.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void RegisterDeath(Tanks.TankController tank)
    {
        Debug.Log("Random Register Death");
        tank.gameObject.SetActive(false);
        Debug.Log(tank.player + " died!");
        Player winner = GetWinner(tank.player);
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
        GameManager.Instance.EndRandomFightPhase(winner);
    }
}
