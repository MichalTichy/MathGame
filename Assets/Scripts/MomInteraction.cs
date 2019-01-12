using System.Diagnostics;
using UnityEngine;

public class MomInteraction : CharacterTextBubbleInteraction
{
    public override void AwardPlayer()
    {
        UnityEngine.Debug.Log("Mom completed!");
        
    }

    protected override void Setup()
    {
        UnityEngine.Debug.Log("Interaction triggered");
    }
}