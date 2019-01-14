using UnityEngine;

public class DogChatInteraction : CharacterTextBubbleInteraction
{
    protected override TriggerMechanism TriggerMechanism => TriggerMechanism.ZoneEnter;


    public IShouldFeedTheDogChatInteraction AfterInteraction;

    [Header("Award")]
    public BoxCollider2D AwardCollider;

    public override bool Completed => !AwardCollider.enabled;

    public override bool ArePostConditionsMet()
    {
        return base.ArePostConditionsMet() && AfterInteraction.HasSausage;
    }

    protected override void BubbleClosed()
    {
        AfterInteraction.StartInteraction();
        End();
    }

    public override void AwardPlayer()
    {
        UnityEngine.Debug.Log("Dog completed!");

        AwardCollider.enabled = false;
    }

    protected override void ChangeCharacterStuffStatus(bool enabled)
    {
        CanTalk = false;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        CanTalk = true;
    }



    protected override void Setup()
    {
        UnityEngine.Debug.Log("Interaction triggered");
    }
}