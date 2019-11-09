using System.Collections;
using System.Collections.Generic;
using TankComponents;
using UnityEngine;

namespace Tanks
{
    public class Level1Tank : MonoBehaviour
    {
        public float mass;

        public Armor armor;
        public Weapon frontWeapon;
        public Weapon rearWeapon;
        public Propulsion propulsion;
        public Flying flying;

        private Rigidbody body;

        private Inputs inputs;

        // Start is called before the first frame update
        void Start()
        {

        }

        void Awake()
        {
            if (frontWeapon)
            {
                frontWeapon.Init();
            }
            if (rearWeapon)
            {
                rearWeapon.Init();
            }
            if (flying)
            {
                flying.Init();
            }
            body = GetComponent<Rigidbody>();
            body.mass = mass;
            if (armor)
            {
                body.mass += armor.mass;
            }

        }

        // Update is called once per frame
        void Update()
        {
            //Read inputs
            inputs.drive = Input.GetAxis("Horizontal");
            inputs.fly = Input.GetAxis("Jump");
            inputs.fireFront = Input.GetButton("Fire1");
            inputs.fireRear = Input.GetButton("Fire2");
        }


        void FixedUpdate()
        {
            if (frontWeapon)
            {
                frontWeapon.Fire(body, inputs.fireFront);
            }
            if (rearWeapon)
            {
                rearWeapon.Fire(body, inputs.fireRear);
            }
            if (flying)
            {
                flying.Fly(body, inputs.fly);
            }
            if (propulsion)
            {
                propulsion.Drive(body, inputs.drive);
            }
        }
    }
}

