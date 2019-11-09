using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerCamera : MonoBehaviour
{

    public List<Transform> targets;
    public Vector3 offset = new Vector3(0, 0, -10);
    public float responsiveness = 0.3f;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnValidate()
    {
        transform.position = GetAveragePositionOfTargets() + offset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = GetAveragePositionOfTargets() + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, responsiveness);
    }

    private Vector3 GetAveragePositionOfTargets()
    {
        if (targets != null && targets.Count > 0)
        {
            Vector3 averagePos = Vector3.zero;
            foreach (Transform t in targets)
            {
                averagePos += t.position;
            }
            return averagePos / targets.Count;
        }
        return Vector3.zero;
    }
}
