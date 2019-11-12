using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankComponents
{
    namespace Flying
    {
        public abstract class AbstractFlying : MonoBehaviour
        {
            public abstract void Fly(Rigidbody body, Transform attachmentPoint, float input);
        }
    }
}

