using UnityEngine;
using UnityEditor;

public class WeaponManuscript : AbstractManuscript
{
    public GameObject projectile;
    public Vector2 muzzleVelocity;
    public float recoil;
    public float cooldown;
    public float projectileMass;

    public WeaponManuscript(ManuscriptSerializable data) : base(data)
    {
        projectile = (GameObject)AssetDatabase.LoadAssetAtPath(data.projectile, typeof(GameObject));
        muzzleVelocity = new Vector2(data.muzzleVelocityX, data.muzzleVelocityY);
        recoil = data.recoilForce;
        cooldown = data.reloadTime;
        projectileMass = data.projectileMass;
    }

}
