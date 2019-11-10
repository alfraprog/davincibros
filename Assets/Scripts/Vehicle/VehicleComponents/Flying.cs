using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankComponents
{
    public class Flying : MonoBehaviour
    {

        public enum FlyMode
        {
            Impulse,
            RampUp,
            Continous
        }

        public FlyMode flyMode;
        public Vector2 force;

        public float staminaUsage;
        public float staminaRecoveryRate;
        public float maxStamina;

        public float currentStamina;
        public float timeUntilReady;
        public float cooldown;

        //Ramp up
        public float rampUpTime;
        public float rampupParameter = 0f;
        private float rampupVelocity = 0f;

        //Continous
        private bool continuousEnabled;

        private bool initialized;

        public FlyingManuscript manuscript;

        public void InitFromManuscript(FlyingManuscript manuscript)
        {
            flyMode = manuscript.flyMode;
            force = manuscript.force;
            staminaUsage = manuscript.staminaUsage;
            staminaRecoveryRate = manuscript.staminaRecoveryRate;
            maxStamina = manuscript.maxStamina;

            cooldown = manuscript.cooldown;
            rampUpTime = manuscript.rampUpTime;

            currentStamina = maxStamina;
            timeUntilReady = 0;
            continuousEnabled = false;
            initialized = true;

            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            if (manuscript.sprite)
            {
                GameObject.Instantiate(manuscript.sprite, transform);
            }
            this.manuscript = manuscript;
        }

        public void Fly(Rigidbody body, float input)
        {
            if (!initialized)
            {
                return;
            }

            switch (flyMode)
            {
                case FlyMode.Impulse:
                    ImpulseFly(body, input);
                    break;
                case FlyMode.RampUp:
                    RampUpFly(body, input);
                    break;
                case FlyMode.Continous:
                    ContinousFly(body, input);
                    break;
            }

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

        private void ImpulseFly(Rigidbody body, float input)
        {
            if (input > 0 && currentStamina >= staminaUsage && timeUntilReady <= 0)
            {
                body.AddForce(new Vector3(0, force.y, force.x), ForceMode.Impulse);
                currentStamina -= staminaUsage;
                timeUntilReady = cooldown;
                PlaySound();
            } else
            {
                RecoverStamina();
                ProgressCooldown();
            }
        }

        private void RampUpFly(Rigidbody body, float input)
        {
            float requiredStamina = staminaUsage * Time.fixedDeltaTime;
            if (input > 0 && currentStamina >= requiredStamina)
            {
                rampupParameter = Mathf.SmoothDamp(rampupParameter, 1, ref rampupVelocity, rampUpTime);

                body.AddForce(new Vector3(0, force.y * rampupParameter, force.x * rampupParameter), ForceMode.Force);
                currentStamina -= requiredStamina;
                PlaySound();
            } else if (rampupParameter >= 0.001f)
            {
                rampupParameter = Mathf.SmoothDamp(rampupParameter, 0, ref rampupVelocity, rampUpTime);

                body.AddForce(new Vector3(0, force.y * rampupParameter, force.x * rampupParameter), ForceMode.Force);

            } else
            {
                RecoverStamina();
            }
        }

        private void ContinousFly(Rigidbody body, float input)
        {
            float requiredStamina = staminaUsage * Time.fixedDeltaTime;
            if (input > 0 && currentStamina >= requiredStamina)
            {
                if (continuousEnabled || timeUntilReady <= 0)
                {
                    body.AddForce(new Vector3(0, force.y, force.x), ForceMode.Force);
                    currentStamina -= requiredStamina;
                    timeUntilReady = cooldown;
                    continuousEnabled = true;
                    PlaySound();
                }

            } else
            {
                continuousEnabled = false;
            }

            if (!continuousEnabled)
            {
                RecoverStamina();
                ProgressCooldown();
            }
        }

        private void PlaySound()
        {
            switch(manuscript.sound)
            {
                case FlyingManuscript.Sound.Rocket:
                    AudioEngine.PlaySound(Sounds.FireWheee);
                    break;
                case FlyingManuscript.Sound.Screw:
                    break;
                case FlyingManuscript.Sound.Spring:
                    break;
                case FlyingManuscript.Sound.Wings:
                    AudioEngine.PlaySound(Sounds.LoudFlap);
                    break;
            }
        }
    }
}
