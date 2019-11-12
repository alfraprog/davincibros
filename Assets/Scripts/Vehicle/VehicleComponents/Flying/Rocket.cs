using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankComponents
{
    namespace Flying
    {
        public class Rocket : AbstractFlying
        {

            public float cooldown;
            public float upwardsAcceleration;
            public float burnTime;

            [FMODUnity.EventRef]
            public string soundEffect;
            public float soundEffectLenght;
  

            private float timeUntilReady = 0f;
            private bool burning = false;

            public override void Fly(Rigidbody body, Transform attachmentPoint, float input)
            {
                if (!burning)
                {
                    if (input > 0 && timeUntilReady <= 0)
                    {
                        burning = true;
                        StartCoroutine(Burn(body));
                        StartCoroutine(PlaySoundEffectOnRepeat());
                    }
                    else
                    {
                        ProgressCooldown();
                    }
                }

            }

            private IEnumerator Burn(Rigidbody body)
            {
                float remainingBurnTime = burnTime;

                while(remainingBurnTime > 0)
                {
                    body.AddRelativeForce(Vector3.up * upwardsAcceleration, ForceMode.Acceleration);
                    yield return new WaitForFixedUpdate();
                    remainingBurnTime -= Time.fixedDeltaTime;
                }

                burning = false;
                timeUntilReady = cooldown;
            }

            private IEnumerator PlaySoundEffectOnRepeat()
            {
                do
                {
                    PlaySoundEffect();
                    yield return new WaitForSeconds(soundEffectLenght);
                } while (burning);
            }

            private void ProgressCooldown()
            {
                if (timeUntilReady > 0)
                {
                    timeUntilReady -= Time.fixedDeltaTime;
                }
            }

            private void PlaySoundEffect()
            {
                if (soundEffect != null && soundEffect.Length > 0)
                {
                    AudioEngine.PlaySound(soundEffect);
                }

            }
        }
    }
}

