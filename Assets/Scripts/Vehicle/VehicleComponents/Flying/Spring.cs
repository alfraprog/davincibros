using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankComponents
{
    namespace Flying
    {
        public class Spring : AbstractFlying
        {

            public float cooldown;
            public float upwardsAcceleration;

            [FMODUnity.EventRef]
            public string soundEffect;

            private float timeUntilReady = 0f;

            public override void Fly(Rigidbody body, Transform attachmentPoint, float input)
            {
                if (input > 0 &&  timeUntilReady <= 0)
                {
                    body.AddRelativeForce(Vector3.up * upwardsAcceleration, ForceMode.Acceleration);
                    timeUntilReady = cooldown;
                    PlaySoundEffect();
                }
                else
                {
                    ProgressCooldown();
                }
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

