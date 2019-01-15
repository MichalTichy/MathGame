using System.Diagnostics;
using UnityEngine;

public class AtticInteraction : CharacterInteractionWithSceneSwitching
{
    [Header("Award")]
    public Stairs stairs;

    public AtticPuzzleArrowController Controller;

    protected override TriggerMechanism TriggerMechanism => TriggerMechanism.Manual;

    public override void AwardPlayer()
    {
        UnityEngine.Debug.Log("Attic completed!");
        stairs.AllowUp = true;
        stairs.GoUp();
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