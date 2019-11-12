using UnityEngine;
using TankComponents;
using static TankComponents.FlyingAttachment;

[CreateAssetMenu(fileName = "Flying Invention", menuName = "Manuscripts/FlyingManuscript", order = 2)]
public class FlyingManuscript : AbstractManuscript
{
    public TankComponents.Flying.AbstractFlying flyingPrefab;
}

