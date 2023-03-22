public enum AnimationNames
{
    Attack,
    Move,
    Idle,
    Block,
    Cast
}

public static class Constants
{
    // Animations
    public const string AnimationSpeedMultiplier = nameof(AnimationSpeedMultiplier);
    public const float BaseAnimationSpeedMultiplier = 1;

    // Movement
    public const float PlayerTurnRateCoeff = 1;
    public const float PlayerMovementSpeedCoeff = 0.01f; // 100 movement speed = +1 movement speed

    // Combat
    public const float PlayerAttackSpeedCoeff = 0.01f; // 100 attack speed = x2 attack speed
}
