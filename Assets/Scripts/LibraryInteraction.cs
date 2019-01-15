using System.Diagnostics;
using UnityEngine;

public class LibraryInteraction : CharacterInteractionWithSceneSwitching
{
    [Header("Award")]
    public BoxCollider2D AwardCollider;

    public DialogBubble Dialog;
    public override void AwardPlayer()
    {
        AwardCollider.enabled = false;
        Dialog.ShowBubble();
        UnityEngine.Debug.Log("Library completed!");
    }

    public bool CorrectBookSelected = false;

    public void CorrectBookFinished()
    {
        CorrectBookSelected = true;
        End();
    }

    public override bool ArePostConditionsMet()
    {
        return base.ArePostConditionsMet() && CorrectBookSelected;
    }

    protected override void Setup()
    {
        UnityEngine.Debug.Log("Interaction triggered");
    }
}