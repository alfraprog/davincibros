using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankComponents
{
    public class Flying : MonoBehaviour
    {

        public float force;
        public void Init()
        {
        }

        public void Fly(Rigidbody body, float input)
        {
            if (input > 0)
            {
                Debug.Log("Flying input = " + input);
                body.AddForce(force * input * Vector3.up, ForceMode.Force);
            }

        }
    }
}
