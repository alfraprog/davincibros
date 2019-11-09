	
using System;

[Serializable]
public class ManuscriptSerializable
{
	public string type;
	public string title;
	public string description;
	public string image;
	public string background;


    //Weapon
    public string projectile;
    public float muzzleVelocityX;
    public float muzzleVelocityY;
    public float recoilForce;
    public float reloadTime;
    public float projectileMass;


}