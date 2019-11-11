using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankComponents
{
    public class Propulsion : MonoBehaviour
    {
        public float driveForce;
        public float brakeForce;

        public void InitFromManuscript(PropulsionManuscript manuscript)
        {
            driveForce = manuscript.driveForce;
            brakeForce = manuscript.brakeForce;

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
            if (manuscript.sprite)
            {
                GameObject.Instantiate(manuscript.sprite, transform);
            }
        }

        public void Drive(Rigidbody body, float input)
        {
            float direction = Mathf.Sign(body.velocity.z);
            if (input == 0)
            {
                body.drag = 0.5f;
            }
            else if (direction == Mathf.Sign(input))
            {
                body.AddForce(Vector3.forward * driveForce * input, ForceMode.Force);
                body.drag = 0f;
            }
            else
            {
                body.AddForce(Vector3.forward * brakeForce * input, ForceMode.Force);
                body.drag = 0f;
            }
        }
    }
}
