using System.Diagnostics;
using UnityEngine;

public class LibraryInteraction : CharacterInteractionWithSceneSwitching
{
    [Header("Award")]
    public BoxCollider2D AwardCollider;
    public override void AwardPlayer()
    {
        UnityEngine.Debug.Log("Library completed!");
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