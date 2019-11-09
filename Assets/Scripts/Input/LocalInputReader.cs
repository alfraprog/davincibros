using System.Collections;
using System.Collections.Generic;
using PlayerInput;
using UnityEngine;

namespace PlayerInput
{
    public class LocalInputReader : InputReader
    {

        private Inputs lastInput;

        public override Inputs ReadInput()
        {
            return lastInput;
        }

        // Start is called before the first frame update
        void Start()
        {
            lastInput = new Inputs();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A)) {
                Debug.Log("A");
            }

            //Read inputs
            lastInput.drive = Input.GetAxis("Horizontal");            
            lastInput.fly = Input.GetAxis("Jump");
            lastInput.fireFront = Input.GetButton("Fire1");
            lastInput.fireRear = Input.GetButton("Fire2");
        }
    }
}

