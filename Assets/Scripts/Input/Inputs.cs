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

        // Manuscripts picking
        public bool manuscript1;
        public bool manuscript2;
        public bool manuscript3;
        public bool manuscript4;
        public bool manuscript5;
        public bool manuscript6;
    }
}

