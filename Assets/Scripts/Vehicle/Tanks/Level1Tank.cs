using System.Collections;
using System.Collections.Generic;
using TankComponents;
using UnityEngine;

namespace Tanks
{
    public class Level1Tank : AbstractTank
    {
        public float mass;

        public Armor armor;
        public Weapon frontWeapon;
        public Weapon rearWeapon;
        public Propulsion propulsion;
        public Flying flying;

        public PlayerInput.InputReader inputReader;

        private Rigidbody body;

        public ArmorManuscript armorManuscript;
        public WeaponManuscript[] weaponManuscripts;
        public PropulsionManuscript propulsionManuscript;
        public FlyingManuscript flyingManuscript;

        // Start is called before the first frame update
        void Start()
        {

        }

        void Awake()
        {
            if (frontWeapon && weaponManuscripts.Length > 0 && weaponManuscripts[0])
            {
                frontWeapon.InitFromManuscript(weaponManuscripts[0]);
            }
            if (rearWeapon && weaponManuscripts.Length > 1 && weaponManuscripts[1])
            {
                rearWeapon.InitFromManuscript(weaponManuscripts[1]);
            }
            if (flying && flyingManuscript)
            {
                flying.InitFromManuscript(flyingManuscript);
            }
            if (propulsionManuscript)
            {
                propulsion.InitFromManuscript(propulsionManuscript);
            }
            body = GetComponent<Rigidbody>();
            body.mass = mass;
            if (armor && armorManuscript)
            {
                armor.InitFromManuscript(armorManuscript);
                body.mass += armor.mass;
            }

        }

        // Update is called once per frame
        void Update()
        {

        }


        void FixedUpdate()
        {
            PlayerInput.Inputs inputs = inputReader.ReadInput();
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

