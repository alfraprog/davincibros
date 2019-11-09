using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float jumpForce = 5f;
    public float thrustForce = 1000f;
    public float brakeForce = 5000f;
    public float rollResistance = 100f;

    private float minTorgue = 0.00000001f;
    private Rigidbody rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    void Awake()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float horizonzalInput = Input.GetAxis("Horizontal");
        float direction = Mathf.Sign(rbody.velocity.z);
        Debug.Log("Velocity = " + rbody.velocity + " Input = " + horizonzalInput);
        if (horizonzalInput == 0)
        {
            rbody.drag = 0.5f;
        }
        else if (direction == Mathf.Sign(horizonzalInput))
        {
            rbody.AddForce(Vector3.forward * thrustForce * horizonzalInput, ForceMode.Force);
            rbody.drag = 0f;
        }
        else
        {
            rbody.AddForce(Vector3.forward * brakeForce * horizonzalInput, ForceMode.Force);
            rbody.drag = 0f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            rbody.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }
    }
}
