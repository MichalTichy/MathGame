using UnityEngine;

public class MomMathInteraction : CharacterInteractionWithSceneSwitching
{
    protected override TriggerMechanism TriggerMechanism => TriggerMechanism.Manual;

    public DialogBubble CompletedDialog;
    public BoxCollider2D MomBoundary;

    public override void AwardPlayer()
    {
        UnityEngine.Debug.Log("Mom completed!");
        MomBoundary.enabled = false;
        CompletedDialog.ShowBubble();
    }

    protected override void Setup()
    {
        UnityEngine.Debug.Log("Interaction triggered");
    }
}