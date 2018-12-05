using System.Diagnostics;
using UnityEngine;

public class HomeworkInteraction : CharacterInteractionWithSceneSwitching
{
    [Header("Award")]
    public Stairs stairs;
    [Header("Character stuffs to disable")]
    public BoxCollider2D characterColider;
    public Canvas characterCanvas;
    public override void AwardPlayer()
    {
        UnityEngine.Debug.Log("Homework completed!");
        stairs.AllowUp = true;

        // Disable NPC and remove quest mark
        characterColider.enabled = false;
        characterCanvas.enabled = false;
    }

    protected override void Setup()
    {
        UnityEngine.Debug.Log("Interaction triggered");
    }
}