using System.Diagnostics;
using UnityEngine;

public class AtticInteraction : CharacterInteractionWithSceneSwitching
{
    [Header("Award")]
    public Stairs stairs;
    [Header("Character stuffs to disable")]
    public Canvas characterCanvas;
    public override void AwardPlayer()
    {
        UnityEngine.Debug.Log("Attic completed!");
        stairs.AllowUp = true;

        // Disable NPC and remove quest mark
        characterCanvas.enabled = false;
    }

    protected override void Setup()
    {
        UnityEngine.Debug.Log("Interaction triggered");
    }
}