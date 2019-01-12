using System.Diagnostics;
using UnityEngine;

public class AtticInteraction : CharacterInteractionWithSceneSwitching
{
    [Header("Award")]
    public Stairs stairs;

    public AtticPuzzleArrowController Controller;
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

    public override bool ArePostConditionsMet()
    {
        return Controller.VerifyCode() && base.ArePostConditionsMet();
    }
}