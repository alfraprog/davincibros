using System.Collections;
using System.Collections.Generic;
using TankComponents;
using UnityEngine;

namespace Tanks
{
    public class Level2Tank : AbstractTank
    {

        public Weapon bottomFrontWeapon;
        public Weapon topFrontWeapon;
        public WeaponManuscript[] frontWeaponManuscripts;

        public Weapon bottomRearWeapon;
        public Weapon topRearWeapon;
        public WeaponManuscript[] rearWeaponManuscripts;


        // Start is called before the first frame update
        void Start()
        {

        }

        public override void Init()
        {
            //Front weapons
            if (bottomFrontWeapon && frontWeaponManuscripts.Length > 0 && frontWeaponManuscripts[0])
            {
                bottomFrontWeapon.InitFromManuscript(frontWeaponManuscripts[0]);
            }
            if (topFrontWeapon && frontWeaponManuscripts.Length > 1 && frontWeaponManuscripts[1])
            {
                topFrontWeapon.InitFromManuscript(frontWeaponManuscripts[1]);
            }

            //Read Weapons
            if (bottomRearWeapon && rearWeaponManuscripts.Length > 0 && rearWeaponManuscripts[0])
            {
                bottomRearWeapon.InitFromManuscript(rearWeaponManuscripts[0]);
            }
            if (topRearWeapon && rearWeaponManuscripts.Length > 1 && rearWeaponManuscripts[1])
            {
                topRearWeapon.InitFromManuscript(rearWeaponManuscripts[1]);
            }


            InitBaseComponents();

        }

        // Update is called once per frame
        void Update()
        {

        }


        void FixedUpdate()
        {
            Inputs inputs = ReadInput();

            //Front weapons
            if (bottomFrontWeapon)
            {
                bottomFrontWeapon.Fire(body, inputs.fireFront);
            }
            if (topFrontWeapon)
            {
                topFrontWeapon.Fire(body, inputs.fireFront);
            }

            // Rear weapons
            if (bottomRearWeapon)
            {
                bottomRearWeapon.Fire(body, inputs.fireRear);
            }
            if (topRearWeapon)
            {
                topRearWeapon.Fire(body, inputs.fireRear);
            }


            //Flying
            if (flying)
            {
                flying.Fly(body, inputs.fly);
            }

            //Propulsion
            if (propulsion)
            {
                propulsion.Drive(body, inputs.drive);
            }
        }
    }
}

