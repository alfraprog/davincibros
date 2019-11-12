using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankComponents
{
    public class FlyingAttachment : MonoBehaviour
    {
        public FlyingManuscript manuscript;

        private Flying.AbstractFlying flying;

        public void InitFromManuscript(FlyingManuscript manuscript)
        {
            if (manuscript)
            {
                this.manuscript = manuscript;

                foreach (Transform child in transform)
                {
                    if (Application.isEditor)
                    {
                        GameObject.DestroyImmediate(child.gameObject);
                    }
                    else
                    {
                        GameObject.Destroy(child.gameObject);
                    }

                }
                if (manuscript.flyingPrefab)
                {
                    flying = GameObject.Instantiate(manuscript.flyingPrefab.gameObject, transform).GetComponent<Flying.AbstractFlying>();
                }
            }
        }

        public void Fly(Rigidbody body, float input)
        {
            if (flying)
            {
                flying.Fly(body, transform, input);
            }

        }
    }
}
