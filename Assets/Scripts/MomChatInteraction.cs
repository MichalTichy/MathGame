using System.Diagnostics;

public class MomChatInteraction : CharacterTextBubbleInteraction
{
    protected override TriggerMechanism TriggerMechanism => TriggerMechanism.ZoneEnter;
    public CharacterMovement CharacterMovement;

    public CharacterInteraction AfterInteraction;

    public override bool Completed => AfterInteraction.Completed;

    protected override void BubbleClosed()
    {
        base.StartInteraction();
        AfterInteraction.StartInteraction();
    }
    public override void StartInteraction()
    {
        CharacterMovement.enabled = false;
        CharacterMovement.Stop();
        base.StartInteraction();
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