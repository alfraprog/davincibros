using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankComponents
{
    namespace Weapons
    {
        public class ProjectileWeaponWithRecoil : AbstractWeapon
        {
            public GameObject canonBall;
            public Vector2 muzzleVelocity;

            public float recoilForce;
            public Vector2 recoilMovement;

            public float reloadTime;

            [FMODUnity.EventRef]
            public string soundEffect;

            public ParticleSystem fireEffect;

            private bool readyToFire = true;

            public override void Fire(Rigidbody tankRigidbody, Transform attachmentPoint, bool fireInput)
            {
                if (fireInput && readyToFire)
                {
                    SpawnProjectile(canonBall, tankRigidbody, attachmentPoint, muzzleVelocity);
                    TriggerFireEffect();
                    PlaySoundEffect();
                    ApplyRecoil(recoilForce, tankRigidbody, attachmentPoint);
                    readyToFire = false;
                    StartCoroutine(Cooldown(attachmentPoint));


                }
            }

            private void TriggerFireEffect()
            {
                if (fireEffect)
                {
                    GameObject effect = Instantiate(fireEffect.gameObject, transform);
                    effect.transform.position = transform.position;
                    effect.GetComponent<ParticleSystem>().Play();
                    Destroy(effect, 5);
                }

            }

            private void PlaySoundEffect()
            {
                if (soundEffect != null && soundEffect.Length > 0)
                {
                    AudioEngine.PlaySound(soundEffect);
                }

            }

            private IEnumerator Cooldown(Transform attachmentPoint)
            {

                if (Vector2.zero.Equals(recoilMovement)) {
                    yield return new WaitForSeconds(reloadTime);
                } else
                {
                    Vector3 currentPos = transform.localPosition;
                    Vector3 recoiledPosition = currentPos + new Vector3(0, recoilMovement.y, recoilMovement.x);

                    float recoilTime = 0.1f;
                    float remainingReloadTime = reloadTime - recoilTime;

                    float t = 0f;
                    while (t < 1)
                    {
                        t += Time.deltaTime / recoilTime;
                        transform.localPosition = Vector3.Lerp(currentPos, recoiledPosition, t);
                        yield return new WaitForFixedUpdate();
                    }
                    t = 0f;
                    while (t < 1)
                    {
                        t += Time.deltaTime / remainingReloadTime;
                        transform.localPosition = Vector3.Lerp(recoiledPosition, currentPos, t);
                        yield return new WaitForFixedUpdate();
                    }
                    readyToFire = true;
                }

            }

        }
    }
}
