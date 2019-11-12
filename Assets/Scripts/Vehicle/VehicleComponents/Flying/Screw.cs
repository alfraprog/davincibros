using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankComponents
{
    namespace Flying
    {
        public class Screw : AbstractFlying
        {
            public float maxStamina;
            public float staminaUseRate;
            public float staminaRecoveryRate;

            public float rampUpTime;
            public float upwardsAcceleration;

            [FMODUnity.EventRef]
            public string soundEffect;

            private float currentStamina;

            private float rampupParameter = 0f;
            private float rampupVelocity = 0f;

            public override void Fly(Rigidbody body, Transform attachmentPoint, float input)
            {

                float requiredStamina = staminaUseRate * Time.fixedDeltaTime;
                if (input > 0 && currentStamina >= requiredStamina)
                {
                    rampupParameter = Mathf.SmoothDamp(rampupParameter, 1, ref rampupVelocity, rampUpTime);

                    body.AddForce(Vector3.up * rampupParameter * upwardsAcceleration, ForceMode.Acceleration);
                    currentStamina -= requiredStamina;
                    PlaySoundEffect();
                } else
                {
                    RecoverStamina();
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

