using System.Diagnostics;
using UnityEngine;

public class CookInteraction : CharacterInteractionWithSceneSwitching
{
    [Header("Award")]
    public BoxCollider2D AwardCollider;
    public override void AwardPlayer()
    {
        UnityEngine.Debug.Log("Cook completed!");
    }

    public override void ChangeInteractionState(bool enabled)
    {
        AwardCollider.enabled = enabled;
        base.ChangeInteractionState(enabled);
    }

    protected override void Setup()
    {
        UnityEngine.Debug.Log("Interaction triggered");
    }
}