using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class FightManager : MonoBehaviour
{
    public PropulsionManuscript basicPropulsion;
    public Tanks.TankController[] tanks;
    // Start is called before the first frame update
    void Start()
    {
        tanks = GameObject.FindObjectsOfType<Tanks.TankController>();
        foreach (Tanks.TankController t in tanks)
        {


            if (t.player == Player.Player1)
            {
                SetupTank(t, GameManager.Instance.tankConfigP1);
            }
            else
            {
                SetupTank(t, GameManager.Instance.tankConfigP2);
            }
            t.SetFightManager(this);
            t.InitComponents();
        }
        AudioEngine.PlaySound(Sounds.StartHorn);
    }

    private void SetupTank(Tanks.TankController tank, GameManager.TankConfig tconf)
    {
        tank.armorManuscript = (ArmorManuscript)tconf.armor_L0;

        tank.leftWeaponManuscripts = new WeaponManuscript[3];
        tank.leftWeaponManuscripts[0] = (WeaponManuscript)tconf.weapon_L0_left;
        tank.leftWeaponManuscripts[1] = (WeaponManuscript)tconf.weapon_L1_left;
        tank.leftWeaponManuscripts[2] = (WeaponManuscript)tconf.weapon_L2_left;

        tank.rightWeaponManuscripts = new WeaponManuscript[3];
        tank.rightWeaponManuscripts[0] = (WeaponManuscript)tconf.weapon_L0_right;
        tank.rightWeaponManuscripts[1] = (WeaponManuscript)tconf.weapon_L1_right;
        tank.rightWeaponManuscripts[2] = (WeaponManuscript)tconf.weapon_L2_right;

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

    public virtual void RegisterDeath(Tanks.TankController tank)
    {
        Debug.Log("Normal Fight manager register death");
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
