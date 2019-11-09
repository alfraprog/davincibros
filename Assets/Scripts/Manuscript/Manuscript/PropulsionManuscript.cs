using UnityEngine;

[CreateAssetMenu(fileName = "Propulsion", menuName = "Manuscripts/PropulsionManuscript", order = 3)]
public class PropulsionManuscript : AbstractManuscript
{
    [SerializeField]
    public float driveForce;
    [SerializeField]
    public float brakeForce;
}
