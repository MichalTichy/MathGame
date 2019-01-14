public class IShouldFeedTheDogChatInteraction : CharacterTextBubbleInteraction
{
    protected override TriggerMechanism TriggerMechanism => TriggerMechanism.Manual;

    public DialogBubble AfterFeed;
    public bool HasSausage;

    public override void StartInteraction()
    {
        if (!HasSausage)
        {
            base.StartInteraction();
        }
        else
        {
            AfterFeed.ShowBubble();
        }

    }
    

    public override bool ArePostConditionsMet()
    {
        return base.ArePostConditionsMet() && HasSausage;
    }

    public override void AwardPlayer()
    {
        UnityEngine.Debug.Log("Dog feed completed!");
    }

    protected override void Setup()
    {
        UnityEngine.Debug.Log("Interaction triggered");
    }
}