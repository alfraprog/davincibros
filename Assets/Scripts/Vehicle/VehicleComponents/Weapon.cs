using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankComponents
{
    public class Weapon : MonoBehaviour
    {
        public WeaponManuscript manuscript;

        private float timeUntilReady = 0;


        private void Start()
        {
        }

        public void InitFromManuscript(WeaponManuscript manuscript)
        {
            if (manuscript)
            {
                this.manuscript = manuscript;
                foreach (Transform child in transform)
                {
                    if (Application.isEditor)
                    {
                        GameObject.DestroyImmediate(child.gameObject);
                    } else
                    {
                        GameObject.Destroy(child.gameObject);
                    }

                }
                if (manuscript.sprite)
                {
                    GameObject.Instantiate(manuscript.sprite, transform);
                }
            }

        }

        public void Fire(Rigidbody body, bool input)
        {
            if (manuscript == null)
            {
                return;
            }

            if (input && manuscript.projectile && timeUntilReady <= 0)
            {
                switch (manuscript.type)
                {
                    case WeaponManuscript.Type.Kinetic:
                        FireKinetic(body);
                        break;
                    case WeaponManuscript.Type.Explosive:
                        FireExplosive(body);
                        break;
                }

                TriggerLaunchEffect();
                ApplyRecoil(body);
                ResetCooldown();

            } else if (timeUntilReady > 0)
            {
                timeUntilReady -= Time.fixedDeltaTime;
            }

        }

        private void TriggerLaunchEffect() {
            if (manuscript.launchEffect != null) {
                GameObject effect = Instantiate(manuscript.launchEffect.gameObject, new Vector3(0, 0, 0), transform.rotation);
                effect.transform.position = transform.position;
                effect.GetComponent<ParticleSystem>().Play();
                Destroy(effect, 5);
            }
        }

        private void FireKinetic(Rigidbody body)
        {

            GameObject projectileInstance = InstantiateProjectile(body);

            projectileInstance.GetComponent<CanonBall>().impactForce = manuscript.impactForce;

            if(manuscript.playSound)
            {
                if (manuscript.powerful)
                {
                    AudioEngine.PlaySound(Sounds.CanonShotPowerful);
                }
                else
                {
                    AudioEngine.PlaySound(Sounds.CanonShot);
                }
            }


        }

        private void FireExplosive(Rigidbody body)
        {
            GameObject projectileInstance = InstantiateProjectile(body);

            Grenade g = projectileInstance.GetComponent<Grenade>();

            g.fuseTime = manuscript.fuseTime;
            g.explosionForce = manuscript.explosionForce;
            g.explosionRadius = manuscript.explosionRadius;
        }

        private GameObject InstantiateProjectile(Rigidbody body)
        {
            GameObject projectileInstance = GameObject.Instantiate(manuscript.projectile, transform);

            Vector3 relativeInitialVelocity = new Vector3(0, manuscript.muzzleVelocity.y, manuscript.muzzleVelocity.x);

            //Rotate vector
            Vector3 velocity = transform.rotation * relativeInitialVelocity;
            projectileInstance.GetComponent<Rigidbody>().velocity = body.velocity + velocity;
            projectileInstance.transform.position = transform.position;

            return projectileInstance;
        }

        private void ResetCooldown()
        {
            timeUntilReady = manuscript.cooldown;
        }

        private void ApplyRecoil(Rigidbody body)
        {
            body.AddForce(transform.rotation * Vector3.back * manuscript.recoil, ForceMode.Impulse);
        }
    }
}
