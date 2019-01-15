using System.Diagnostics;
using UnityEngine;

public class CookInteraction : CharacterInteractionWithSceneSwitching
{

    protected DialogBubble EndMessageBubble;
    public DialogBubble SuccessBubble;
    public DialogBubble FailBubble;
    protected bool Succeeded = false;

    [Header("Award")]
    public BoxCollider2D AwardCollider;
    public override void AwardPlayer()
    {
        UnityEngine.Debug.Log("Cook completed!");
        AwardCollider.enabled = false;

    }

    public void WrongAnswer()
    {
        EndMessageBubble = FailBubble;
        End();
    }

    public void CorrectAnswer()
    {
        EndMessageBubble = SuccessBubble;
        Succeeded = true;
        End();
    }

    public override void StartInteraction()
    {
        base.StartInteraction();
        EndMessageBubble = null;
    }

    protected override void TransferControlBackToMainGame()
    {
        base.TransferControlBackToMainGame();
        EndMessageBubble?.ShowBubble();
    }

    public override bool ArePostConditionsMet()
    {

        return base.ArePostConditionsMet() && Succeeded;
    }

    protected override void Setup()
    {
        UnityEngine.Debug.Log("Interaction triggered");
    }
}