using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float jumpForce = 5f;

    private Rigidbody rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        foreach (AxleInfo axleInfo in axleInfos)
        {
            float input = Input.GetAxis("Horizontal");
            if (input == 0)
            {
                axleInfo.wheel.motorTorque = 0;
                axleInfo.wheel.brakeTorque = axleInfo.brakeTorque * 0.5f;
            }
            else if (Mathf.Sign(rbody.velocity.z) == Mathf.Sign(input))
            {
                axleInfo.wheel.motorTorque = axleInfo.motorTorque * input;
                axleInfo.wheel.brakeTorque = 0;
            } else
            {
                axleInfo.wheel.motorTorque = 0;
                axleInfo.wheel.brakeTorque = axleInfo.brakeTorque * Mathf.Abs(input);
            }

        }

        if (Input.GetButtonDown("Jump"))
        {
            rbody.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }
    }

    [System.Serializable]
    public class AxleInfo
    {
        public WheelCollider wheel;
        public float motorTorque;
        public float brakeTorque;
    }
}
