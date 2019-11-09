using Photon.Pun;
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

        public PlayerInput.InputReader inputReader;

        private Rigidbody body;

        private PhotonView photonView;

        // Start is called before the first frame update
        void Start()
        {

        }

        void Awake()
        {
            photonView = GetComponent<PhotonView>();
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

        }


        void FixedUpdate()
        {   
            if (!photonView.IsMine) // || !controllable
            {
                return;
            }

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

