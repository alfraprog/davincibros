using UnityEngine;

namespace PlayerInput
{
    public abstract class InputReader : MonoBehaviour
    {
        public abstract Inputs ReadInput();
    }

    public struct Inputs
    {
        public float drive;
        public float fly;
        public bool fireFront;
        public bool fireRear;
    }
}

