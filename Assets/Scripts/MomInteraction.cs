using System.Diagnostics;
using UnityEngine;

public class MomInteraction : CharacterTextBubbleInteraction
{
    protected override TriggerMechanism TriggerMechanism
    {
        get { return TriggerMechanism.ZoneEnter; }
    }



    public override void AwardPlayer()
    {
        UnityEngine.Debug.Log("Mom completed!");
        
    }

    protected override void Setup()
    {
        UnityEngine.Debug.Log("Interaction triggered");
    }
}