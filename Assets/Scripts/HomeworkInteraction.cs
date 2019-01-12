using System.Diagnostics;
using UnityEngine;

public class HomeworkInteraction : CharacterInteractionWithSceneSwitching
{
    [Header("Award")]
    public Stairs stairs;
    public override void AwardPlayer()
    {
        UnityEngine.Debug.Log("Homework completed!");
        stairs.AllowUp = true;
    }

    protected override void Setup()
    {
        UnityEngine.Debug.Log("Interaction triggered");
    }
}