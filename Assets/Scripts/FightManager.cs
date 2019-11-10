using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class FightManager : MonoBehaviour
{
    public PropulsionManuscript basicPropulsion;
    public Tanks.AbstractTank[] tanks;
    // Start is called before the first frame update
    void Start()
    {
        tanks = GameObject.FindObjectsOfType<Tanks.AbstractTank>();
        foreach (Tanks.AbstractTank t in tanks)
        {


            if (t.player == Player.Player1)
            {
                SetupTank(t, GameManager.Instance.tankConfigP1);
            } else
            {
                SetupTank(t, GameManager.Instance.tankConfigP2);
            }
            t.SetFightManager(this);
            t.Init();
        }
        AudioEngine.PlaySound(Sounds.StartHorn);
    }

    private void SetupTank(Tanks.AbstractTank tank, GameManager.TankConfig tconf)
    {
        if (tank is Tanks.Level1Tank)
            SetupTank1((Tanks.Level1Tank)tank, tconf);
        if (tank is Tanks.Level2Tank)
            SetupTank2((Tanks.Level2Tank)tank, tconf);

    }

    private void SetupTank1(Tanks.Level1Tank tank, GameManager.TankConfig tconf)
    {
        if (tconf.armor_L0 != null) tank.armorManuscript = (ArmorManuscript)tconf.armor_L0;
        if (tconf.armor_L1 != null) tank.armorManuscript = (ArmorManuscript)tconf.armor_L1;
        if (tconf.armor_L2 != null) tank.armorManuscript = (ArmorManuscript)tconf.armor_L2;

        tank.weaponManuscripts = new WeaponManuscript[2];
        tank.weaponManuscripts[0] = (WeaponManuscript)tconf.weapon_L0_right;
        tank.weaponManuscripts[1] = (WeaponManuscript)tconf.weapon_L0_left;


        tank.flyingManuscript = (FlyingManuscript)tconf.flight;

        if (tconf.wheel_left != null) tank.propulsionManuscript = (PropulsionManuscript)tconf.wheel_left;
        if (tconf.wheel_right != null) tank.propulsionManuscript = (PropulsionManuscript)tconf.wheel_right;

        if (tank.propulsionManuscript == null)
        {
            tank.propulsionManuscript = basicPropulsion;
        }
    }

    private void SetupTank2(Tanks.Level2Tank tank, GameManager.TankConfig tconf)
    {
        if (tconf.armor_L0 != null) tank.armorManuscript = (ArmorManuscript)tconf.armor_L0;
        if (tconf.armor_L1 != null) tank.armorManuscript = (ArmorManuscript)tconf.armor_L1;
        if (tconf.armor_L2 != null) tank.armorManuscript = (ArmorManuscript)tconf.armor_L2;

        tank.frontWeaponManuscripts = new WeaponManuscript[2];
        tank.frontWeaponManuscripts[0] = (WeaponManuscript)tconf.weapon_L0_right;
        tank.frontWeaponManuscripts[1] = (WeaponManuscript)tconf.weapon_L1_right;

        tank.rearWeaponManuscripts = new WeaponManuscript[2];
        tank.rearWeaponManuscripts[0] = (WeaponManuscript)tconf.weapon_L0_left;
        tank.rearWeaponManuscripts[1] = (WeaponManuscript)tconf.weapon_L1_left;

        tank.flyingManuscript = (FlyingManuscript)tconf.flight;

        if (tconf.wheel_left != null) tank.propulsionManuscript = (PropulsionManuscript)tconf.wheel_left;
        if (tconf.wheel_right != null) tank.propulsionManuscript = (PropulsionManuscript)tconf.wheel_right;

        if (tank.propulsionManuscript == null)
        {
            tank.propulsionManuscript = basicPropulsion;
        }
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
