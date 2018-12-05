using System.Diagnostics;
using UnityEngine;

public class MomInteraction : CharacterInteractionWithSceneSwitching
{
    [Header("Character stuffs to disable")]
    public BoxCollider2D characterColider;
    public Canvas characterCanvas;
    public override void AwardPlayer()
    {
        UnityEngine.Debug.Log("Mom completed!");

        // Disable NPC and remove quest mark
        characterColider.enabled = false;
        characterCanvas.enabled = false;
    }

    protected override void Setup()
    {
        UnityEngine.Debug.Log("Interaction triggered");
    }
}