using UnityEngine;
using UnityEditor;
using TankComponents.Weapons;

[CreateAssetMenu(fileName = "Weapon", menuName = "Manuscripts/WeaponManuscript", order = 1)]
public class WeaponManuscript : AbstractManuscript
{
    public AbstractWeapon weaponPrefab;
}
