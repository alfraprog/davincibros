// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Asteroid.cs" company="Exit Games GmbH">
//   Part of: Asteroid Demo
// </copyright>
// <summary>
//  Asteroid Component
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

using Random = UnityEngine.Random;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

namespace Photon.Pun.Demo.Asteroids
{
    public class CannonController : MonoBehaviour
    {
        public Player Owner { get; private set; }

        public void Start()
        {
            Destroy(gameObject, 3.0f);
        }

        public void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }

        public void InitializeCannon(Player owner, Vector3 originalDirection, float lag)
        {
            Owner = owner;

            transform.forward = originalDirection;

            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.velocity = originalDirection * 200.0f;
            rigidbody.position += rigidbody.velocity * lag;
        }
    }
}