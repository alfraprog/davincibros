using System.Collections;
using System.Collections.Generic;
using PlayerInput;
using UnityEngine;

namespace PlayerInput
{
    public class LocalInputReader : InputReader
    {
        public string horizontal = "Horizontal_P1";
        public string jump = "Jump_P1";
        public string fire1 = "Fire1_P1";
        public string fire2 = "Fire2_P1";

        public override Inputs ReadInput()
        {
            Inputs lastInput;
            lastInput.drive = Input.GetAxis(horizontal);
            lastInput.fly = Input.GetAxis(jump);
            lastInput.fireFront = Input.GetButton(fire1);
            lastInput.fireRear = Input.GetButton(fire2);
            return lastInput;
        }

    }
}

