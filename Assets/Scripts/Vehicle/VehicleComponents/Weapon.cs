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
        public float impactForce;

        private float timeUntilReady = 0;

        private bool initialized;

        public void InitFromManuscript(WeaponManuscript manuscript)
        {
            projectile = manuscript.projectile;
            muzzleVelocity = manuscript.muzzleVelocity;
            recoil = manuscript.recoil;
            cooldown = manuscript.cooldown;
            impactForce = manuscript.impactForce;
            initialized = true;
        }

        public void Fire(Rigidbody body, bool input)
        {
            if (!initialized)
            {
                return;
            }

            if (input && projectile && timeUntilReady <= 0)
            {
                GameObject projectileInstance = GameObject.Instantiate(projectile, transform);

                Vector3 relativeInitialVelocity = new Vector3(0, muzzleVelocity.y, muzzleVelocity.x);

                //Rotate vector
                Vector3 velocity = transform.rotation * relativeInitialVelocity;

                projectileInstance.GetComponent<CanonBall>().impactForce = impactForce;
                projectileInstance.GetComponent<Rigidbody>().velocity = body.velocity + velocity;
                projectileInstance.transform.position = transform.position;

                body.AddForce(transform.rotation * Vector3.back * recoil, ForceMode.Impulse);
                timeUntilReady = cooldown;

                AudioEngine.PlaySound(Sounds.CanonShotPowerful);
            } else if (timeUntilReady > 0)
            {
                timeUntilReady -= Time.fixedDeltaTime;
            }

        }
    }
}
