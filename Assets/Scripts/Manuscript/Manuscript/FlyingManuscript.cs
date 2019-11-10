using UnityEngine;
using TankComponents;
using static TankComponents.Flying;

[CreateAssetMenu(fileName = "Flying Invention", menuName = "Manuscripts/FlyingManuscript", order = 2)]
public class FlyingManuscript : AbstractManuscript
{
    public enum Sound
    {
        Rocket,
        Spring,
        Wings,
        Screw
    }

    [SerializeField]
    public FlyMode flyMode;
    [SerializeField]
    public Vector2 force;

    [SerializeField]
    public float staminaUsage;
    [SerializeField]
    public float staminaRecoveryRate;
    [SerializeField]
    public float maxStamina;

    [SerializeField]
    public float cooldown;

    //Ramp up
    [SerializeField]
    public float rampUpTime;

    public Sound sound;
}

