using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class AbstractTank : MonoBehaviour
    {
        public string playerName = "Player";
        public FightManager fightManager;

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Death"))
            {
                fightManager.RegisterDeath(this);
            }
        }

    }
}
