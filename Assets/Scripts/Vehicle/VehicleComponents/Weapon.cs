using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankComponents
{
    public class Weapon : MonoBehaviour
    {

        public GameObject projectile;
        public Vector2 muzzleVelocity;
        public float cooldown;

        private float timeUntilReady = 0;

        public void Init()
        {
        }

        public void Fire(Rigidbody body, bool input)
        {
            if (input && projectile && timeUntilReady <= 0)
            {
                GameObject instance = GameObject.Instantiate(projectile, transform);

                Vector3 relativeInitialVelocity = new Vector3(0, muzzleVelocity.y, muzzleVelocity.x);

                //Rotate vector
                Vector3 velocity = transform.rotation * relativeInitialVelocity;

                instance.GetComponent<Rigidbody>().velocity = body.velocity + velocity;
                instance.transform.position = transform.position;
                timeUntilReady = cooldown;
            } else if (timeUntilReady > 0)
            {
                timeUntilReady -= Time.fixedDeltaTime;
            }

        }
    }
}
