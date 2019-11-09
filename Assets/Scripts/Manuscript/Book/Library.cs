using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{
    public WeaponManuscript[] weaponManuscripts;
    public FlyingManuscript[] flyingManuscripts;
    public PropulsionManuscript[] propulsionManuscripts;
    public ArmorManuscript[] armorManuscripts;

    void Start()
    {
        weaponManuscripts = Resources.LoadAll<WeaponManuscript>("Manuscripts/Weapons");
        flyingManuscripts = Resources.LoadAll<FlyingManuscript>("Manuscripts/Flying");
        propulsionManuscripts = Resources.LoadAll<PropulsionManuscript>("Manuscripts/Propulsion");
        armorManuscripts = Resources.LoadAll<ArmorManuscript>("Manuscripts/Armor");

        Debug.Log("Loaded library");
    }

}
