using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankComponents
{
    namespace Weapons
    {
        public abstract class AbstractWeapon : MonoBehaviour
        {
            public abstract void Fire(Rigidbody tankRigidbody, Transform parent, bool fireInput);

            protected T SpawnProjectile<T>(T prefab, Rigidbody tankRigidbody, Transform attachmentPoint, Vector2 muzzleVelocity) where T : MonoBehaviour {

                GameObject projectileInstance = GameObject.Instantiate(prefab.gameObject, attachmentPoint);


                //Rotate vector
                Vector3 velocity = attachmentPoint.rotation * muzzleVelocity;
                projectileInstance.GetComponent<Rigidbody>().velocity = tankRigidbody.velocity + velocity;
                projectileInstance.transform.position = attachmentPoint.position;

                return projectileInstance.GetComponent<T>();
            }

            protected GameObject SpawnProjectile(GameObject prefab, Rigidbody tankRigidbody, Transform attachmentPoint, Vector2 muzzleVelocity)
            {

                GameObject projectileInstance = GameObject.Instantiate(prefab.gameObject, attachmentPoint);


                //Rotate vector
                Vector3 velocity = attachmentPoint.rotation * new Vector3(0, muzzleVelocity.y, muzzleVelocity.x);
                projectileInstance.GetComponent<Rigidbody>().velocity = tankRigidbody.velocity + velocity;
                projectileInstance.transform.position = attachmentPoint.position;

                return projectileInstance;
            }


            protected void ApplyRecoil(float recoil, Rigidbody tankRigidbody, Transform attachmentPoint)
            {
                tankRigidbody.AddForce(attachmentPoint.rotation * Vector3.back * recoil, ForceMode.Impulse);
            }
        }
    }

}
