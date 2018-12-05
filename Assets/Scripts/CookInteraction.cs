using System.Diagnostics;
using UnityEngine;

public class CookInteraction : CharacterInteractionWithSceneSwitching
{
    [Header("Award")]
    public BoxCollider2D AwardCollider;
    [Header("Character stuffs to disable")]
    public BoxCollider2D characterColider;
    public Canvas characterCanvas;
    public override void AwardPlayer()
    {
        AwardCollider.enabled = false;
        UnityEngine.Debug.Log("Cook completed!");
        // Disable NPC and remove quest mark
        characterColider.enabled = false;
        characterCanvas.enabled = false;
    }

    protected override void Setup()
    {
        UnityEngine.Debug.Log("Interaction triggered");
    }
}