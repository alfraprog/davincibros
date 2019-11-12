using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankComponents
{
    namespace Flying
    {
        public class Wings : AbstractFlying
        {
            public float maxStamina;
            public float staminaPerUse;
            public float staminaRecoveryRate;
            public float cooldown;
            public float upwardsAcceleration;

            [FMODUnity.EventRef]
            public string soundEffect;

            private float currentStamina;
            private float timeUntilReady = 0f;

            public override void Fly(Rigidbody body, Transform attachmentPoint, float input)
            {
                if (input > 0 && currentStamina >= staminaPerUse && timeUntilReady <= 0)
                {
                    body.AddRelativeForce(Vector3.up * upwardsAcceleration, ForceMode.Acceleration);
                    currentStamina -= staminaPerUse;
                    timeUntilReady = cooldown;
                    PlaySoundEffect();
                }
                else
                {
                    RecoverStamina();
                    ProgressCooldown();
                }
            }

            // Start is called before the first frame update
            void Start()
            {
                currentStamina = maxStamina;
            }

            private void RecoverStamina()
            {
                if (currentStamina < maxStamina)
                {
                    currentStamina = Mathf.Clamp(currentStamina + staminaRecoveryRate * Time.fixedDeltaTime, 0, maxStamina);
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

