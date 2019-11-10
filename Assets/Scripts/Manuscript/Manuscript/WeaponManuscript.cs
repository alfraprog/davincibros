using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Weapon", menuName = "Manuscripts/WeaponManuscript", order = 1)]
public class WeaponManuscript : AbstractManuscript
{
    public GameObject projectile;
    public Vector2 muzzleVelocity;
    public float recoil;
    public float cooldown;
    public float impactForce;
    public bool powerful;

}
