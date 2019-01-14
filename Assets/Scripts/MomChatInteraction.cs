using System.Diagnostics;

public class MomChatInteraction : CharacterTextBubbleInteraction
{
    protected override TriggerMechanism TriggerMechanism => TriggerMechanism.ZoneEnter;


    public CharacterInteraction AfterInteraction;

    public override bool Completed => AfterInteraction.Completed;

    protected override void BubbleClosed()
    {
        base.StartInteraction();
        AfterInteraction.StartInteraction();
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