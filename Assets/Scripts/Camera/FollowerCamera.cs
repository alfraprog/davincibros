using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerCamera : MonoBehaviour
{

    public List<Transform> targets;
    public float maxY = 0;
    public float minY = 0;
    public float responsiveness = 0.3f;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnValidate()
    {
        float y = Mathf.Clamp(GetAveragePositionOfTargets().y, minY, maxY);
        Vector3 newPos = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
        transform.localPosition = newPos;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float y = Mathf.Clamp(GetAveragePositionOfTargets().y, minY, maxY);
        Vector3 targetPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, targetPosition, ref velocity, responsiveness);
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
