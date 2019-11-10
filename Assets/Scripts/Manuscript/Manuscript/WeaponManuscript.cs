using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Weapon", menuName = "Manuscripts/WeaponManuscript", order = 1)]
public class WeaponManuscript : AbstractManuscript
{
    public enum Type
    {
        Kinetic,
        Explosive
    }

    public Type type;
    public GameObject projectile;
    public Vector2 muzzleVelocity;
    public float recoil;
    public float cooldown;
    public float impactForce;
    public bool powerful;

    public float fuseTime;
    public float explosionForce;
    public float explosionRadius;
    public ParticleSystem launchEffect;
}
