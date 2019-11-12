using System.Collections;
using System.Collections.Generic;
using TankComponents;
using UnityEngine;
using static GameManager;

namespace Tanks
{
    public class TankController : MonoBehaviour
    {


        public Player player = Player.Player1;

        public float chassisMass;

        public WeaponAttachment[] leftWeapons;
        public WeaponAttachment[] rightWeapons;
        public Armor armor;
        public Propulsion propulsion;
        public Flying flying;

        public WeaponManuscript[] leftWeaponManuscripts;
        public WeaponManuscript[] rightWeaponManuscripts;
        public ArmorManuscript armorManuscript;
        public PropulsionManuscript propulsionManuscript;
        public FlyingManuscript flyingManuscript;

        private FightManager fightManager;
        protected Rigidbody body;

        public void InitComponents()
        {
            for (int i = 0; i < leftWeapons.Length && i < leftWeaponManuscripts.Length; i++)
            {
                leftWeapons[i].InitFromManuscript(leftWeaponManuscripts[i]);
            }
            for (int i = 0; i < rightWeapons.Length && i < rightWeaponManuscripts.Length; i++)
            {
                rightWeapons[i].InitFromManuscript(rightWeaponManuscripts[i]);
            }

            if (flying && flyingManuscript)
            {
                flying.InitFromManuscript(flyingManuscript);
            }
            if (propulsion && propulsionManuscript)
            {
                propulsion.InitFromManuscript(propulsionManuscript);
            }
            body = GetComponent<Rigidbody>();
            body.mass = chassisMass;
            if (armor && armorManuscript)
            {
                armor.InitFromManuscript(armorManuscript);
                body.mass += armor.mass;
            }
        }

        private void FixedUpdate()
        {
            Inputs inputs = ReadInput();

            for (int i = 0; i < leftWeapons.Length && i < leftWeaponManuscripts.Length; i++)
            {
                leftWeapons[i].Fire(body, inputs.fireLeft);
            }
            for (int i = 0; i < rightWeapons.Length && i < rightWeaponManuscripts.Length; i++)
            {
                rightWeapons[i].Fire(body, inputs.fireRight);
            }

            if (flying && flyingManuscript)
            {
                flying.Fly(body, inputs.fly);
            }
            if (propulsion && propulsionManuscript)
            {
                propulsion.Drive(body, inputs.drive);
            }
        }

        public void SetFightManager(FightManager manager)
        {
            this.fightManager = manager;
        }

        protected Inputs ReadInput()
        {
            string suffix = GetInputSuffix();
            Inputs lastInput;
            lastInput.drive = Input.GetAxis("Horizontal" + suffix);
            lastInput.fly = Input.GetAxis("Jump" + suffix);
            lastInput.fireRight = Input.GetButton("Fire1" + suffix);
            lastInput.fireLeft = Input.GetButton("Fire2" + suffix);
            return lastInput;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Death"))
            {
                fightManager.RegisterDeath(this);
                AudioEngine.PlaySound(Sounds.FireWheeeHit);
            } else if (collision.gameObject.CompareTag("Player"))
            {
                AudioEngine.PlaySound(Sounds.ImpactTanks);
            } 
        }

        private string GetInputSuffix()
        {
            switch(player)
            {
                case Player.Player1:
                    return "_P1";
                case Player.Player2:
                    return "_P2";
            }
            return "_P1";
        }

        protected struct Inputs
        {
            public float drive;
            public float fly;
            public bool fireRight;
            public bool fireLeft;
        }

    }
}
