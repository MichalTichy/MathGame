using System.Diagnostics;
using UnityEngine;

public class DogInteraction : CharacterInteractionWithSceneSwitching
{
    [Header("Award")]
    public BoxCollider2D AwardCollider;
 
    public override void AwardPlayer()
    {
        UnityEngine.Debug.Log("Dog completed!");
        AwardCollider.enabled = false;

    }

    protected override void Setup()
    {
        UnityEngine.Debug.Log("Interaction triggered");
    }
}