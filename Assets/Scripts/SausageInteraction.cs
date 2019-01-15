using UnityEngine;

public class SausageInteraction : CharacterInteraction
{
    public IShouldFeedTheDogChatInteraction FeedTheDogChatInteraction;
    public DialogBubble Dialog;
    public SpriteRenderer Sausage;

    public bool DogHasSpoken;
    protected override TriggerMechanism TriggerMechanism => TriggerMechanism.ZoneEnter;


    public override void AwardPlayer()
    {
        FeedTheDogChatInteraction.HasSausage = true;
        Sausage.enabled = false;
    }

    public override void StartInteraction()
    {
        if (!ArePreConditionsMet())
            return;
        
        Dialog.ShowBubble();
        base.StartInteraction();
        End();
    }

    protected override bool ArePreConditionsMet()
    {
        return base.ArePreConditionsMet() && FeedTheDogChatInteraction.HasSausage==false && DogHasSpoken;
    }

    protected override void Setup()
    {
        
    }
}