using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankComponents
{
    public class WeaponAttachment : MonoBehaviour
    {
        public WeaponManuscript manuscript;
        private Weapons.AbstractWeapon weapon;

        public void InitFromManuscript(WeaponManuscript manuscript)
        {
            if (manuscript)
            {
                this.manuscript = manuscript;

                foreach (Transform child in transform)
                {
                    if (Application.isEditor)
                    {
                        GameObject.DestroyImmediate(child.gameObject);
                    } else
                    {
                        GameObject.Destroy(child.gameObject);
                    }

                }
                if (manuscript.weaponPrefab)
                {
                    weapon = GameObject.Instantiate(manuscript.weaponPrefab.gameObject, transform).GetComponent<Weapons.AbstractWeapon>();
                }
            }

        }

        public void Fire(Rigidbody body, bool input)
        {
            if (weapon)
            {
                weapon.Fire(body, transform, input);
            }



        }
    }
}
