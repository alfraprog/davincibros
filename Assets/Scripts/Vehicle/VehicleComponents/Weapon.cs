using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankComponents
{
    public class Weapon : MonoBehaviour
    {
        public void Init()
        {
        }

        public void Fire(Rigidbody body, bool input)
        {
            if (input)
            {
                Debug.Log("Fire Weapon");
            }

        }
    }
}
