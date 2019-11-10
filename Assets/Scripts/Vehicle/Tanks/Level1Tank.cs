using System.Collections;
using System.Collections.Generic;
using TankComponents;
using UnityEngine;

namespace Tanks
{
    public class Level1Tank : AbstractTank
    {

        public Weapon frontWeapon;
        public Weapon rearWeapon;

        public WeaponManuscript[] weaponManuscripts;


        // Start is called before the first frame update
        void Start()
        {

        }

        public override void Init()
        {

            if (frontWeapon && weaponManuscripts.Length > 0 && weaponManuscripts[0])
            {
                frontWeapon.InitFromManuscript(weaponManuscripts[0]);
            }
            if (rearWeapon && weaponManuscripts.Length > 1 && weaponManuscripts[1])
            {
                rearWeapon.InitFromManuscript(weaponManuscripts[1]);
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

