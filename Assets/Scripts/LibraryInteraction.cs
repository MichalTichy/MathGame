using System.Diagnostics;
using UnityEngine;

public class LibraryInteraction : CharacterInteractionWithSceneSwitching
{
    [Header("Award")]
    public BoxCollider2D AwardCollider;
    public override void AwardPlayer()
    {
        AwardCollider.enabled = false;
        UnityEngine.Debug.Log("Library completed!");
    }

    protected override void Setup()
    {
        UnityEngine.Debug.Log("Interaction triggered");
    }
}