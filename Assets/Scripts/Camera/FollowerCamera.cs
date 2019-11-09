using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerCamera : MonoBehaviour
{

    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -10);
    public float responsiveness = 0.3f;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnValidate()
    {
        if (target)
        {
            transform.position = target.position + offset;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, responsiveness);

        }
    }
}
