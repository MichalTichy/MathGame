using UnityEngine;

public class IShouldFeedTheDogChatInteraction : CharacterTextBubbleInteraction
{
    protected override TriggerMechanism TriggerMechanism => TriggerMechanism.Manual;
    public Collider2D AwardCollider;
    public DialogBubble AfterFeed;
    public bool HasSausage;


    public override void StartInteraction()
    {
        if (Completed)
            return;

        if (!HasSausage)
        {
            base.StartInteraction();
        }
        else
        {
            AfterFeed.ShowBubble();
            End();
        }

    }
    

    public override bool ArePostConditionsMet()
    {
        return base.ArePostConditionsMet() && HasSausage;
    }

    public override void AwardPlayer()
    {
        AwardCollider.enabled = false;
        UnityEngine.Debug.Log("Dog feed completed!");
    }

    protected override void Setup()
    {
        UnityEngine.Debug.Log("Interaction triggered");
    }
}