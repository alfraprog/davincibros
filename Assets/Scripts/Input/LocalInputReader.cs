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
        public string manuscript1 = "Manuscript1_P1";
        public string manuscript2 = "Manuscript2_P1";
        public string manuscript3 = "Manuscript3_P1";
        public string manuscript4 = "Manuscript4_P1";
        public string manuscript5 = "Manuscript5_P1";
        public string manuscript6 = "Manuscript6_P1";

        public override Inputs ReadInput()
        {
            Inputs lastInput;
            lastInput.drive = Input.GetAxis(horizontal);
            lastInput.fly = Input.GetAxis(jump);
            lastInput.fireFront = Input.GetButton(fire1);
            lastInput.fireRear = Input.GetButton(fire2);

            lastInput.manuscript1 = Input.GetButton(manuscript1);
            lastInput.manuscript2 = Input.GetButton(manuscript2);
            lastInput.manuscript3 = Input.GetButton(manuscript3);
            lastInput.manuscript4 = Input.GetButton(manuscript4);
            lastInput.manuscript5 = Input.GetButton(manuscript5);
            lastInput.manuscript6 = Input.GetButton(manuscript6);
            return lastInput;
        }

    }
}

