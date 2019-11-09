using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankComponents
{
    public class Weapon : MonoBehaviour
    {

        public GameObject projectile;
        public Vector2 muzzleVelocity;
        public float recoil;
        public float cooldown;
        public float projectileMass;

        private float timeUntilReady = 0;

        public void Init()
        {
        }

        public void InitFromManuscript(WeaponManuscript manuscript)
        {
            projectile = manuscript.projectile;
            muzzleVelocity = manuscript.muzzleVelocity;
            recoil = manuscript.recoil;
            cooldown = manuscript.cooldown;
            projectileMass = manuscript.projectileMass;
        }

        public void Fire(Rigidbody body, bool input)
        {
            if (input && projectile && timeUntilReady <= 0)
            {
                GameObject projectileInstance = GameObject.Instantiate(projectile, transform);

                Vector3 relativeInitialVelocity = new Vector3(0, muzzleVelocity.y, muzzleVelocity.x);

                //Rotate vector
                Vector3 velocity = transform.rotation * relativeInitialVelocity;

                projectileInstance.GetComponent<Rigidbody>().velocity = body.velocity + velocity;
                projectileInstance.GetComponent<Rigidbody>().mass = projectileMass;
                projectileInstance.transform.position = transform.position;

                body.AddForce(transform.rotation * Vector3.back * recoil, ForceMode.Impulse);
                timeUntilReady = cooldown;
            } else if (timeUntilReady > 0)
            {
                timeUntilReady -= Time.fixedDeltaTime;
            }

        }
    }
}
