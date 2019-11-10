using System.Collections;
using System.Collections.Generic;
using TankComponents;
using UnityEngine;

namespace Tanks
{
    public class AbstractTank : MonoBehaviour
    {
        public enum Player
        {
            Player1,
            Player2
        }

        public Player player = Player.Player1;

        public float chassisMass;

        public Armor armor;
        public Propulsion propulsion;
        public Flying flying;

        public ArmorManuscript armorManuscript;
        public PropulsionManuscript propulsionManuscript;
        public FlyingManuscript flyingManuscript;

        private FightManager fightManager;
        protected Rigidbody body;

        protected void InitBaseComponents()
        {
            if (flying && flyingManuscript)
            {
                flying.InitFromManuscript(flyingManuscript);
            }
            if (propulsionManuscript)
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
            lastInput.fireFront = Input.GetButton("Fire1" + suffix);
            lastInput.fireRear = Input.GetButton("Fire2" + suffix);
            return lastInput;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Death"))
            {
                fightManager.RegisterDeath(this);
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
            public bool fireFront;
            public bool fireRear;
        }

    }
}
